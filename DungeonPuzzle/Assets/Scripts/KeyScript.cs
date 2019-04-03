using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private const string KEY = "DungeonPuzzleLevelKey";
    private char[] keyValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadKey()
    {
        if (PlayerPrefs.HasKey(KEY))
        {
            keyValue = PlayerPrefs.GetString(KEY).ToCharArray();
        }
        else
        {
            keyValue = new char[1];
            keyValue[0] = '0';
        }
    }

    public char[] GetKeyValue()
    {
        return keyValue;
    }

    public void UpdateKey(int levelIndex, int value)
    {
        char a = char.Parse(value.ToString());
        if (levelIndex >= keyValue.Length)
        {
            char[] temp = new char[levelIndex + 1];
            for (int i = 0; i < keyValue.Length; i++)
            {
                temp[i] = keyValue[i];
            }
            keyValue = temp;
        }
        keyValue[levelIndex] = a;
    }

    public bool IsUpdateNeeded(int levelIndex, int value)
    {
        if (levelIndex >= keyValue.Length)
        {
            return true;
        }
        else
        {
            if ((int)char.GetNumericValue(keyValue[levelIndex]) < value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public void SaveKey()
    {
        PlayerPrefs.SetString(KEY, new string(keyValue));
    }

    public int GetKeyNumericalValue(int levelIndex)
    {
        return (int)char.GetNumericValue(keyValue[levelIndex]);
    }
}