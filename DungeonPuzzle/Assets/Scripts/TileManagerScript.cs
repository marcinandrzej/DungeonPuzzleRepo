using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManagerScript : MonoBehaviour
{
    private const float HEIGHT = 2.5f;
    private const int X_OFFSET = 10;
    private const int Y_OFFSET = -10;

    private TileScript startTile;
    private TileScript endTile;
    private GameObject[,] tiles;
    private List<TileScript> path;

    public TileScript StartTile
    {
        get
        {
            return startTile;
        }
    }

    public GameObject GetTile(int x, int y)
    {
        return tiles[x, y];
    }

    public void SetUpTiles(Transform parent, MapClass map, GameObject[] tilePrefabs)
    {
        int[,] tileMap = map.tileMap;
        tiles = new GameObject[tileMap.GetLength(0), tileMap.GetLength(1)];
        for (int x = 0; x < tiles.GetLength(0); x++)
        {
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                if (tileMap[x, y] != 0)
                {
                    tiles[x, y] = Instantiate(tilePrefabs[tileMap[x, y] - 1], parent.transform, false);
                    tiles[x, y].GetComponent<TileScript>().SetPosition(x, y, CalculatePosition(x, y, tileMap[x, y] == 1 ? HEIGHT : 0));
                    if (tiles[x, y].tag == "START")
                    {
                        startTile = tiles[x, y].GetComponent<TileScript>();
                    }
                    else if (tiles[x, y].tag == "END")
                    {
                        endTile = tiles[x, y].GetComponent<TileScript>();
                    }
                }
            }
        }
    }
   
    public bool CanBeMoved(int x, int y)
    {
        if(tiles[x,y] == null)
            return true;
        return false;
    }

    public void UpdateIndexes(int x, int y, int deltax, int deltay)
    {
        GameObject activeTile = tiles[x, y];
        tiles[x, y] = null;
        tiles[x + deltax, y + deltay] = activeTile;
    }

    public List<TileScript> CheckIfEnd()
    {
        int listCount = 0;
        path = new List<TileScript>();
        path.Add(startTile);
        while (listCount != path.Count)
        {
            listCount = path.Count;
            TileScript tile = path[path.Count - 1];
            CheckTile(tiles[tile.XIndex + tile.xExit1, tile.YIndex + tile.yExit1], tile, 0);
            CheckTile(tiles[tile.XIndex + tile.xExit2, tile.YIndex + tile.yExit2], tile, 1);
        }
        if (path.Contains(endTile) && path.Contains(startTile))
            return path;
        return null;
    }

    private void CheckTile(GameObject _tile, TileScript _enteringTile, int entryIndex)
    {
        if (_tile != null)
        {
            TileScript tileScr = _tile.GetComponent<TileScript>();
            if (!path.Contains(tileScr) && tileScr.passable == true)
            {
                if (entryIndex == 0)
                {
                    if ((tileScr.xExit1 == -(_enteringTile.xExit1) && tileScr.yExit1 == -(_enteringTile.yExit1)) || 
                        (tileScr.xExit2 == -(_enteringTile.xExit1) && tileScr.yExit2 == -(_enteringTile.yExit1)))
                    {
                        path.Add(tileScr);
                    }
                }
                else
                {
                    if ((tileScr.xExit1 == -(_enteringTile.xExit2) && tileScr.yExit1 == -(_enteringTile.yExit2)) || 
                        (tileScr.xExit2 == -(_enteringTile.xExit2) && tileScr.yExit2 == -(_enteringTile.yExit2)))
                    {
                        path.Add(tileScr);
                    }
                }
            }
        }
    }

    public Vector3 CalculatePosition(int x, int y, float hight)
    {
        Vector3 calculatedPos = new Vector3((x - 1) * X_OFFSET, hight, (y - 1) * Y_OFFSET);
        return calculatedPos;
    }

    public void DestroyAllTiles()
    {
        int dX = tiles.GetLength(0);
        int dY = tiles.GetLength(1);
        for (int x = 0; x < dX; x++)
        {
            for (int y = 0; y < dY; y++)
            {
                if (tiles[x, y] != null)
                {
                    Destroy(tiles[x, y]);
                }
            }
        }
    }

    public bool TilesTableInUse()
    {
        if (tiles != null)
            return true;
        return false;
    }
}
