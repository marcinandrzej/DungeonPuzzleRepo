using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMapsScript : MonoBehaviour
{
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

        MapClass mapp = new MapClass(9, map);
        List<MapClass> mpsList = new List<MapClass>();
        mpsList.Add(mapp);
        Save("/mapki.dat", mpsList);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Save(string fileName, List<MapClass> maps)
    {
        BinaryFormatter bFormater = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + fileName);
        for (int i = 0; i < maps.Count; i++)
        {
            bFormater.Serialize(file, maps[i]);
        }
        file.Close();
    }
}
