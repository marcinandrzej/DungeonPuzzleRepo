using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript instance;
    private const float SPEED = 0.5f;

    public TileManagerScript tileManager;
    private ControllScript controllScript;
    private MapManagerScript mapManager;

    private MapClass currentMap;
    public CharaterScript character;

    private int currentLevel;
    private int moves;

    public GameObject tilesParent;

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
        //tileManager = gameObject.AddComponent<TileManagerScript>();
        mapManager = gameObject.AddComponent<MapManagerScript>();
        controllScript = gameObject.AddComponent<ControllScript>();

        mapManager.LoadMaps("/mapki.dat");
        SetUpGame(tilesParent.transform, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool CanBeMoved(int x, int y)
    {
        return tileManager.CanBeMoved(x, y);
    }

    public void MoveTile(int x, int y, int deltax, int deltay, TileScript tile)
    {
        moves++;
        GameMenuScript.instance.UpdateMovesText(moves);
        GameObject activeTile = tileManager.GetTile(x, y);
        tileManager.UpdateIndexes(x, y, deltax, deltay);
        StartCoroutine(tile.Move(tileManager.CalculatePosition(tile.XIndex + deltax, tile.YIndex + deltay, activeTile.transform.position.y),
                            SPEED, deltax, deltay));
    }

    public void CheckIfEnd()
    {
        List<TileScript> characterPath = tileManager.CheckIfEnd();
        if (characterPath != null)
        {
            controllScript.enabled = false;
            StartCoroutine(character.Move(characterPath, SPEED));
        }
    }

    public void SetUpGame(Transform parent, int level)
    {
        MapClass map = mapManager.GetMap(level);
        if (map != null)
        {
            currentMap = map;
            tileManager.SetUpTiles(parent, map);
            SetUpCharacter(tileManager.StartTile);
            SetUpGui(level);
            controllScript.enabled = true;
        }
    }

    private void SetUpCharacter(TileScript startTile)
    {
        character.transform.localPosition = new Vector3(startTile.transform.localPosition.x, 7, startTile.transform.localPosition.z);
    }

    private void SetUpGui(int level)
    {
        currentLevel = level;
        moves = 0;
        GameMenuScript.instance.UpdateMovesText(moves);
        GameMenuScript.instance.UpdateCoinText(currentMap.moves, currentMap.moves + 2, currentMap.moves + 5);
        GameMenuScript.instance.UpdateLevelText(level + 1);
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
        GameMenuScript.instance.ShowWinMenu(CalculateCoins());
    }
}
