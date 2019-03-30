using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapClass 
{
    public int moves;
    public int[,] tileMap;

    public MapClass(int _moves, int[,] _tileMap)
    {
        moves = _moves;
        tileMap = new int[_tileMap.GetLength(0), _tileMap.GetLength(1)];
        for (int i = 0; i < tileMap.GetLength(0); i++)
        {
            for (int j = 0; j < tileMap.GetLength(1); j++)
            {
                tileMap[i, j] = _tileMap[i, j];
            }
        }
    }
}
