using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManagerScript : MonoBehaviour
{
    private const int X_OFFSET = 10;
    private const int Y_OFFSET = -10;
    private const float SPEED = 0.5f;

    public static TileManagerScript instance;
    public GameObject[] tilePrefabs;
    private GameObject[,] tiles;
    public GameObject tilesParent;

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
        map[1, 1] = 5;
        map[1, 2] = 4;
        map[2, 2] = 5;
        map[3, 2] = 6;
        map[3, 3] = 7;

        SetUpTiles(tilesParent.transform, map);
    }
	
	// Update is called once per frame
	void Update () {
		
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
                    tiles[x, y].GetComponent<TileScript>().SetPosition(x, y, CalculatePosition(x, y, 0));
                }
            }
        }
    }

    public Vector3 CalculatePosition(int x, int y, float hight)
    {
        Vector3 calculatedPos = new Vector3((x - 1) * X_OFFSET, hight, (y - 1) * Y_OFFSET);
        return calculatedPos;
    }
}
