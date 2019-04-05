using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript instance;
    private const float SPEED = 0.5f;

    private KeyScript keyScript;
    private TileManagerScript tileManagerScript;
    private ControllScript controllScript;
    private MapManagerScript mapManagerScript;
    public GameMenuScript gameMenuScript;

    private MapClass currentMap;
    private CharaterScript character;
    private Coroutine characterMovementCoroutine;

    private int currentLevel;
    private int moves;

    public GameObject tilesParent;
    public GameObject[] tilePrefabs;
    public GameObject characterPrefab;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }

    // Use this for initialization
    void Start ()
    {
        keyScript = gameObject.AddComponent<KeyScript>();
        tileManagerScript = gameObject.AddComponent<TileManagerScript>();
        mapManagerScript = gameObject.AddComponent<MapManagerScript>();
        controllScript = gameObject.AddComponent<ControllScript>();

        controllScript.enabled = false;
        keyScript.LoadKey();
        if (!mapManagerScript.IsDataFile("/mapki.dat"))
        {
            SaveMapsScript s = gameObject.AddComponent<SaveMapsScript>();
            mapManagerScript.LoadMaps(s.PrepareData());
        }
        else
        {
            mapManagerScript.LoadMaps("/mapki.dat");
        }

        buttonAction action = SetUpGame;
        gameMenuScript.SetUpLevelButtons(action);
        gameMenuScript.UpdateLevelButtons(keyScript.GetKeyValue());

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public bool CanBeMoved(int x, int y)
    {
        return tileManagerScript.CanBeMoved(x, y);
    }

    public void MoveTile(int x, int y, int deltax, int deltay, TileScript tile)
    {
        moves++;
        gameMenuScript.UpdateMovesText(moves);
        GameObject activeTile = tileManagerScript.GetTile(x, y);
        tileManagerScript.UpdateIndexes(x, y, deltax, deltay);
        StartCoroutine(tile.Move(tileManagerScript.CalculatePosition(tile.XIndex + deltax, tile.YIndex + deltay, activeTile.transform.position.y),
                            SPEED, deltax, deltay));
    }

    public void CheckIfEnd()
    {
        List<TileScript> characterPath = tileManagerScript.CheckIfEnd();
        if (characterPath != null)
        {
            controllScript.enabled = false;
            characterMovementCoroutine = StartCoroutine(character.Move(characterPath, SPEED/2));
        }
    }

    public void SetUpGame(int level)
    {
        AudioScript.instance.StopAllSoundes();
        gameMenuScript.HideWinMenu(false);
        MapClass map = mapManagerScript.GetMap(level);
        if (map != null)
        {
            currentMap = map;
            if (tileManagerScript.TilesTableInUse())
            {
                tileManagerScript.DestroyAllTiles();
            }
            tileManagerScript.SetUpTiles(tilesParent.transform, map, tilePrefabs);
            SetUpCharacter(tileManagerScript.StartTile);
            SetUpGui(level);
            gameMenuScript.HideLevelMenu(false);
            controllScript.enabled = true;
        }
    }

    private void SetUpCharacter(TileScript startTile)
    {
        if (character == null)
        {
            character = Instantiate(characterPrefab, tilesParent.transform, false).AddComponent<CharaterScript>();
            character.SetAnimator();
        }
        if (characterMovementCoroutine != null)
            StopCoroutine(characterMovementCoroutine);
        character.transform.localPosition = new Vector3(startTile.transform.localPosition.x, 5, startTile.transform.localPosition.z);
        character.StopMove();
    }

    private void SetUpGui(int level)
    {
        currentLevel = level;
        moves = 0;
        gameMenuScript.UpdateMovesText(moves);
        gameMenuScript.UpdateCoinText(currentMap.moves, currentMap.moves + 2, currentMap.moves + 5);
        gameMenuScript.UpdateLevelText(level + 1);
    }

    public int CalculateCoins()
    {
        if (moves <= currentMap.moves)
            return 3;
        if (moves <= currentMap.moves + 2)
            return 2;
        if (moves <= currentMap.moves + 5)
            return 1;
        return 0;
    }

    public void EndLevel()
    {
        bool save = false;
        int coins = CalculateCoins();
        bool isNextLevel = mapManagerScript.IsNextLevel(currentLevel);
        if (coins > 0)
        {
            if (keyScript.IsUpdateNeeded(currentLevel, coins))
            {
                keyScript.UpdateKey(currentLevel, coins);
                save = true;
            }
            if (isNextLevel && keyScript.IsUpdateNeeded(currentLevel + 1, 0))
            {
                keyScript.UpdateKey(currentLevel + 1, 0);
                save = true;
            }
            if(save)
                keyScript.SaveKey();
        }
        AudioScript.instance.PlayFanfares();
        gameMenuScript.ShowWinMenu(coins, (isNextLevel && keyScript.GetKeyNumericalValue(currentLevel) > 0));
    }

    public void RestartLevel()
    {
        SetUpGame(currentLevel);
    }

    public void NextLevel()
    {
        SetUpGame(currentLevel + 1);
    }

    public void LevelMenuShow(bool show)
    {
        AudioScript.instance.StopAllSoundes();
        if (characterMovementCoroutine != null)
            StopCoroutine(characterMovementCoroutine);
        gameMenuScript.UpdateLevelButtons(keyScript.GetKeyValue());
        gameMenuScript.HideLevelMenu(show);
    }
}
