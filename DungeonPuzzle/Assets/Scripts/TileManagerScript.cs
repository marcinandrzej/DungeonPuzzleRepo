using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManagerScript : MonoBehaviour
{
    private const int X_OFFSET = 10;
    private const int Y_OFFSET = -10;

    private TileScript startTile;
    private TileScript endTile;
    private List<TileScript> path;
    private GameObject[,] tiles;
    public static TileManagerScript instance;
    public GameObject[] tilePrefabs;
    public GameObject tilesParent;
    public ControllScript controllScript;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }

	// Use this for initialization
	void Start ()
    {
        int[,] map = new int[5, 5];
        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                map[x, y] = 1;
            }
        }
        for (int x = 1; x < map.GetLength(0) - 1; x++)
        {
            for (int y = 1; y < map.GetLength(1) - 1; y++)
            {
                map[x, y] = 0;
            }
        }
        map[2, 0] = 3;
        map[2, 4] = 2;
        map[1, 1] = 8;
        map[1, 2] = 4;
        map[2, 2] = 9;
        map[3, 2] = 6;
        map[3, 3] = 7;

        SetUpTiles(tilesParent.transform, map);
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void SetUpTiles(Transform parent, int[,] tileMap)
    {
        tiles = new GameObject[tileMap.GetLength(0), tileMap.GetLength(1)];
        for (int x = 0; x < tiles.GetLength(0); x++)
        {
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                if (tileMap[x, y] != 0)
                {
                    tiles[x, y] = Instantiate(tilePrefabs[tileMap[x, y] - 1], tilesParent.transform, false);
                    tiles[x, y].GetComponent<TileScript>().SetPosition(x, y, CalculatePosition(x, y, tileMap[x, y] == 1 ? 2.5f : 0));
                }
            }
        }
        startTile = GameObject.FindGameObjectWithTag("START").GetComponent<TileScript>();
        endTile = GameObject.FindGameObjectWithTag("END").GetComponent<TileScript>();
        controllScript.enabled = true;
    }

    public Vector3 CalculatePosition(int x, int y, float hight)
    {
        Vector3 calculatedPos = new Vector3((x - 1) * X_OFFSET, hight, (y - 1) * Y_OFFSET);
        return calculatedPos;
    }

    public bool CanBeMoved(int x, int y)
    {
        if(tiles[x,y] == null)
            return true;
        return false;
    }

    public void MoveTile(int x, int y, int deltax, int deltay, TileScript tile, float speed)
    {
        GameObject activeTile = tiles[x, y];
        tiles[x, y] = null;
        tiles[x + deltax, y + deltay] = activeTile;
        StartCoroutine(tile.Move(CalculatePosition(tile.XIndex + deltax, tile.YIndex + deltay, activeTile.transform.position.y),
                            speed, deltax, deltay));
    }

    public void CheckIfEnd()
    {
        int listCount = 0;
        path = new List<TileScript>();
        path.Add(startTile);
        while (listCount != path.Count)
        {
            listCount = path.Count;
            TileScript tile = path[path.Count - 1];
            CheckTile(tiles[tile.XIndex + tile.xExit1, tile.YIndex + tile.yExit1], tile);
            CheckTile(tiles[tile.XIndex + tile.xExit2, tile.YIndex + tile.yExit2], tile);
        }
        if (path.Contains(endTile) && path.Contains(startTile))
        {
            controllScript.enabled = false;
        }
    }

    public void CheckTile(GameObject _tile, TileScript _enteringTile)
    {
        if (_tile != null)
        {
            TileScript tileScr = _tile.GetComponent<TileScript>();
            if (!path.Contains(tileScr) && tileScr.passable == true)
            {
                if ((tileScr.xExit1 == -(_enteringTile.xExit1) && tileScr.yExit1 == -(_enteringTile.yExit1)) ||
                    (tileScr.xExit2 == -(_enteringTile.xExit2) && tileScr.yExit2 == -(_enteringTile.yExit2)) ||
                    (tileScr.xExit1 == -(_enteringTile.xExit2) && tileScr.yExit1 == -(_enteringTile.yExit2)) ||
                    (tileScr.xExit2 == -(_enteringTile.xExit1) && tileScr.yExit2 == -(_enteringTile.yExit1)))
                {
                    path.Add(tileScr);
                }
            }
        }
    }
}
