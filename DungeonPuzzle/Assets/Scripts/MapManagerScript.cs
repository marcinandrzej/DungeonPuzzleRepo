using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManagerScript : MonoBehaviour
{
    private List<MapClass> maps;

    public bool LoadMaps(string fileName)
    {
        string filePath = (Application.streamingAssetsPath + fileName);
        if (File.Exists(filePath))
        {
            maps = new List<MapClass>();
            BinaryFormatter bFormater = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);
            while (file.Position != file.Length)
            {
                maps.Add((MapClass)bFormater.Deserialize(file));
            }
            file.Close();
            return true;
        }
        else
        {
            return false;
        }
    }

    public MapClass GetMap(int level)
    {
        if(level < maps.Count)
            return maps[level];
        return null;
    }

    public bool IsNextLevel(int currentlevel)
    {
        if (currentlevel < maps.Count - 1)
            return true;
        return false;
    }
}
