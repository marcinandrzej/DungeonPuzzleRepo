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

        //Debug.Log("done");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Save(string fileName)
    {
        List<MapClass> maps = PrepareData();
        BinaryFormatter bFormater = new BinaryFormatter();
        FileStream file = File.Create(Application.streamingAssetsPath + fileName);
        for (int i = 0; i < maps.Count; i++)
        {
            bFormater.Serialize(file, maps[i]);
        }
        file.Close();
    }

    public List<MapClass> PrepareData()
    {
        /*
         * 0 - empty
         * 1 - impassable tile
         * 2 - start
         * 3 - end
         * 4 - forward-backward tile
         * 5 - left-right tile
         * 6 - bottom-left tile
         * 7 - bottom-right tile
         * 8 - forwrd-left tile
         * 9 - forward-right tile
         */
        List<MapClass> mpsList = new List<MapClass>();
        
        /******************LEVEL 1***************/
        int[,] map = CreateEmptyMap(5);
        //start
        map[1, 4] = 2;
        //end
        map[2, 0] = 3;
        //tiles
        map[2, 1] = 9;
        map[3, 1] = 6;
        map[2, 2] = 5;
        map[1, 3] = 7;
        map[2, 3] = 8;
        map[3, 3] = 4;
        //Save map
        MapClass mapp = new MapClass(3, map);
        mpsList.Add(mapp);


        /******************LEVEL 2***************/
        map = CreateEmptyMap(5);
        //start
        map[2, 4] = 2;
        //end
        map[1, 0] = 3;
        //tiles
        map[1, 1] = 9;
        map[3, 1] = 4;
        map[2, 2] = 5;
        map[3, 2] = 6;
        map[2, 3] = 7;
        map[3, 3] = 8;
        //Save map
        mapp = new MapClass(3, map);
        mpsList.Add(mapp);

        /******************LEVEL 3***************/
        map = CreateEmptyMap(5);
        //start
        map[3, 4] = 2;
        //end
        map[2, 0] = 3;
        //tiles
        map[2, 1] = 6;
        map[2, 2] = 9;
        map[3, 2] = 4;
        map[2, 3] = 4;
        //Save map
        mapp = new MapClass(3, map);
        mpsList.Add(mapp);

        /******************LEVEL 4***************/
        map = CreateEmptyMap(5);
        //start
        map[2, 4] = 2;
        //end
        map[2, 0] = 3;
        //tiles
        map[1, 1] = 7;
        map[2, 1] = 6;
        map[1, 2] = 9;
        map[3, 2] = 8;
        map[2, 3] = 4;
        //Save map
        mapp = new MapClass(3, map);
        mpsList.Add(mapp);

        /******************LEVEL 5***************/
        map = CreateEmptyMap(5);
        //start
        map[1, 4] = 2;
        //end
        map[3, 0] = 3;
        //tiles
        map[1, 1] = 7;
        map[3, 1] = 8;
        map[1, 2] = 9;
        map[2, 2] = 5;
        map[3, 2] = 6;
        map[1, 3] = 7;
        map[3, 3] = 8;
        //Save map
        mapp = new MapClass(3, map);
        mpsList.Add(mapp);

        /******************LEVEL 6***************/
        map = CreateEmptyMap(5);
        //start
        map[3, 4] = 2;
        //end
        map[3, 0] = 3;
        //tiles
        map[1, 1] = 7;
        map[2, 1] = 5;
        map[3, 1] = 8;
        map[1, 2] = 9;
        map[3, 2] = 6;
        map[1, 3] = 4;
        map[2, 3] = 5;
        //Save map
        mapp = new MapClass(3, map);
        mpsList.Add(mapp);

        /******************LEVEL 7***************/
        map = CreateEmptyMap(5);
        //start
        map[1, 4] = 2;
        //end
        map[2, 0] = 3;
        //tiles
        map[1, 1] = 9;
        map[3, 1] = 6;
        map[2, 3] = 5;
        map[1, 2] = 7;
        map[3, 3] = 8;
        map[2, 1] = 4;
        //Save map
        mapp = new MapClass(4, map);
        mpsList.Add(mapp);

        /******************LEVEL 8***************/
        map = CreateEmptyMap(5);
        //start
        map[2, 4] = 2;
        //end
        map[1, 0] = 3;
        //tiles
        map[1, 1] = 4;
        map[3, 1] = 5;
        map[1, 2] = 9;
        map[3, 2] = 6;
        map[1, 3] = 7;
        map[2, 3] = 8;
        //Save map
        mapp = new MapClass(4, map);
        mpsList.Add(mapp);

        /******************LEVEL 9***************/
        map = CreateEmptyMap(5);
        //start
        map[3, 4] = 2;
        //end
        map[2, 0] = 3;
        //tiles
        map[3, 1] = 6;
        map[3, 2] = 4;
        map[1, 3] = 4;
        map[2, 3] = 9;
        //Save map
        mapp = new MapClass(4, map);
        mpsList.Add(mapp);

        /******************LEVEL 10***************/
        map = CreateEmptyMap(5);
        //start
        map[2, 4] = 2;
        //end
        map[2, 0] = 3;
        //tiles
        map[1, 1] = 7;
        map[2, 1] = 8;
        map[3, 1] = 6;
        map[1, 2] = 9;
        map[3, 2] = 4;
        //Save map
        mapp = new MapClass(4, map);
        mpsList.Add(mapp);

        /******************LEVEL 11***************/
        map = CreateEmptyMap(5);
        //start
        map[1, 4] = 2;
        //end
        map[3, 0] = 3;
        //tiles
        map[1, 1] = 7;
        map[2, 1] = 5;
        map[1, 2] = 9;
        map[2, 2] = 8;
        map[3, 2] = 6;
        map[1, 3] = 7;
        map[3, 3] = 8;
        //Save map
        mapp = new MapClass(4, map);
        mpsList.Add(mapp);

        /******************LEVEL 12***************/
        map = CreateEmptyMap(5);
        //start
        map[3, 4] = 2;
        //end
        map[3, 0] = 3;
        //tiles
        map[1, 1] = 7;
        map[3, 1] = 5;
        map[1, 2] = 9;
        map[2, 2] = 6;
        map[3, 2] = 8;
        map[2, 3] = 5;
        map[3, 3] = 4;
        //Save map
        mapp = new MapClass(4, map);
        mpsList.Add(mapp);

        /******************LEVEL 13***************/
        map = CreateEmptyMap(5);
        //start
        map[1, 4] = 2;
        //end
        map[2, 0] = 3;
        //tiles
        map[1, 1] = 7;
        map[2, 1] = 9;
        map[3, 1] = 6;
        map[2, 2] = 4;
        map[1, 3] = 5;
        map[2, 3] = 8;
        //Save map
        mapp = new MapClass(5, map);
        mpsList.Add(mapp);

        /******************LEVEL 14***************/
        map = CreateEmptyMap(5);
        //start
        map[2, 4] = 2;
        //end
        map[1, 0] = 3;
        //tiles
        map[1, 1] = 4;
        map[2, 1] = 7;
        map[3, 1] = 5;
        map[1, 2] = 9;
        map[2, 2] = 6;
        map[3, 3] = 8;
        //Save map
        mapp = new MapClass(5, map);
        mpsList.Add(mapp);

        /******************LEVEL 15***************/
        map = CreateEmptyMap(5);
        //start
        map[3, 4] = 2;
        //end
        map[2, 0] = 3;
        //tiles
        map[1, 1] = 6;
        map[1, 2] = 4;
        map[2, 2] = 9;
        map[3, 3] = 4;
        //Save map
        mapp = new MapClass(5, map);
        mpsList.Add(mapp);

        /******************LEVEL 16***************/
        map = CreateEmptyMap(5);
        //start
        map[2, 4] = 2;
        //end
        map[2, 0] = 3;
        //tiles
        map[1, 1] = 7;
        map[2, 2] = 9;
        map[3, 2] = 6;
        map[2, 3] = 8;
        map[3, 3] = 4;
        //Save map
        mapp = new MapClass(5, map);
        mpsList.Add(mapp);

        /******************LEVEL 17***************/
        map = CreateEmptyMap(5);
        //start
        map[1, 4] = 2;
        //end
        map[3, 0] = 3;
        //tiles
        map[1, 1] = 7;
        map[2, 1] = 5;
        map[3, 1] = 6;
        map[1, 2] = 9;
        map[2, 2] = 8;
        map[1, 3] = 7;
        map[3, 3] = 8;
        //Save map
        mapp = new MapClass(5, map);
        mpsList.Add(mapp);

        /******************LEVEL 18***************/
        map = CreateEmptyMap(5);
        //start
        map[3, 4] = 2;
        //end
        map[3, 0] = 3;
        //tiles
        map[1, 1] = 7;
        map[2, 1] = 8;
        map[1, 2] = 5;
        map[2, 2] = 5;
        map[3, 2] = 6;
        map[2, 3] = 9;
        map[3, 3] = 4;
        //Save map
        mapp = new MapClass(5, map);
        mpsList.Add(mapp);

        /******************LEVEL 19***************/
        map = CreateEmptyMap(5);
        //start
        map[1, 4] = 2;
        //end
        map[2, 0] = 3;
        //tiles
        map[1, 1] = 7;
        map[2, 1] = 6;
        map[1, 2] = 5;
        map[2, 2] = 9;
        map[3, 2] = 4;
        map[3, 3] = 8;
        //Save map
        mapp = new MapClass(6, map);
        mpsList.Add(mapp);

        /******************LEVEL 20***************/
        map = CreateEmptyMap(5);
        //start
        map[2, 4] = 2;
        //end
        map[1, 0] = 3;
        //tiles
        map[2, 1] = 5;
        map[3, 1] = 4;
        map[2, 2] = 9;
        map[3, 2] = 6;
        map[1, 3] = 7;
        map[2, 3] = 8;
        //Save map
        mapp = new MapClass(6, map);
        mpsList.Add(mapp);

        /******************LEVEL 21***************/
        map = CreateEmptyMap(5);
        //start
        map[3, 4] = 2;
        //end
        map[2, 0] = 3;
        //tiles
        map[1, 1] = 4;
        map[2, 1] = 6;
        map[3, 2] = 9;
        map[3, 3] = 4;
        //Save map
        mapp = new MapClass(6, map);
        mpsList.Add(mapp);

        /******************LEVEL 22***************/
        map = CreateEmptyMap(5);
        //start
        map[2, 4] = 2;
        //end
        map[2, 0] = 3;
        //tiles
        map[1, 2] = 9;
        map[2, 2] = 6;
        map[3, 2] = 7;
        map[2, 3] = 4;
        map[3, 3] = 8;
        //Save map
        mapp = new MapClass(6, map);
        mpsList.Add(mapp);

        /******************LEVEL 23***************/
        map = CreateEmptyMap(5);
        //start
        map[1, 4] = 2;
        //end
        map[3, 0] = 3;
        //tiles
        map[1, 1] = 7;
        map[2, 1] = 5;
        map[3, 1] = 8;
        map[3, 2] = 8;
        map[1, 3] = 7;
        map[2, 3] = 9;
        map[3, 3] = 6;
        //Save map
        mapp = new MapClass(6, map);
        mpsList.Add(mapp);

        /******************LEVEL 24***************/
        map = CreateEmptyMap(5);
        //start
        map[3, 4] = 2;
        //end
        map[3, 0] = 3;
        //tiles
        map[1, 1] = 7;
        map[3, 1] = 5;
        map[1, 2] = 9;
        map[2, 2] = 5;
        map[3, 2] = 8;
        map[1, 3] = 4;
        map[2, 3] = 6;
        //Save map
        mapp = new MapClass(6, map);
        mpsList.Add(mapp);

        /******************LEVEL 25***************/
        map = CreateEmptyMap(5);
        //start
        map[1, 4] = 2;
        //end
        map[2, 0] = 3;
        //tiles
        map[1, 1] = 9;
        map[2, 1] = 4;
        map[1, 2] = 7;
        map[2, 2] = 6;
        map[1, 3] = 5;
        map[3, 3] = 8;
        //Save map
        mapp = new MapClass(7, map);
        mpsList.Add(mapp);

        /******************LEVEL 26***************/
        map = CreateEmptyMap(5);
        //start
        map[2, 4] = 2;
        //end
        map[1, 0] = 3;
        //tiles
        map[2, 1] = 7;
        map[3, 1] = 6;
        map[2, 2] = 4;
        map[3, 2] = 5;
        map[1, 3] = 9;
        map[3, 3] = 8;
        //Save map
        mapp = new MapClass(7, map);
        mpsList.Add(mapp);

        /******************LEVEL 27***************/
        map = CreateEmptyMap(5);
        //start
        map[3, 4] = 2;
        //end
        map[2, 0] = 3;
        //tiles
        map[1, 1] = 6;
        map[1, 2] = 4;
        map[3, 2] = 4;
        map[2, 3] = 9;
        //Save map
        mapp = new MapClass(7, map);
        mpsList.Add(mapp);

        /******************LEVEL 28***************/
        map = CreateEmptyMap(5);
        //start
        map[2, 4] = 2;
        //end
        map[2, 0] = 3;
        //tiles
        map[1, 2] = 6;
        map[2, 2] = 8;
        map[1, 3] = 9;
        map[2, 3] = 4;
        map[3, 3] = 7;
        //Save map
        mapp = new MapClass(7, map);
        mpsList.Add(mapp);

        /******************LEVEL 29***************/
        map = CreateEmptyMap(5);
        //start
        map[1, 4] = 2;
        //end
        map[3, 0] = 3;
        //tiles
        map[1, 1] = 7;
        map[2, 1] = 5;
        map[1, 2] = 9;
        map[2, 2] = 6;
        map[3, 2] = 8;
        map[2, 3] = 8;
        map[3, 3] = 7;
        //Save map
        mapp = new MapClass(7, map);
        mpsList.Add(mapp);

        /******************LEVEL 30***************/
        map = CreateEmptyMap(5);
        //start
        map[3, 4] = 2;
        //end
        map[3, 0] = 3;
        //tiles
        map[1, 1] = 7;
        map[2, 1] = 5;
        map[3, 1] = 8;
        map[1, 2] = 9;
        map[2, 2] = 5;
        map[1, 3] = 6;
        map[3, 3] = 4;
        //Save map
        mapp = new MapClass(7, map);
        mpsList.Add(mapp);

        /******************LEVEL 31***************/
        map = CreateEmptyMap(5);
        //start
        map[1, 4] = 2;
        //end
        map[2, 0] = 3;
        //tiles
        map[1, 1] = 9;
        map[3, 1] = 6;
        map[2, 2] = 4;
        map[1, 3] = 7;
        map[2, 3] = 8;
        map[3, 3] = 5;
        //Save map
        mapp = new MapClass(8, map);
        mpsList.Add(mapp);

        /******************LEVEL 32***************/
        map = CreateEmptyMap(5);
        //start
        map[2, 4] = 2;
        //end
        map[1, 0] = 3;
        //tiles
        map[2, 1] = 4;
        map[3, 1] = 7;
        map[1, 2] = 9;
        map[2, 2] = 5;
        map[3, 2] = 6;
        map[3, 3] = 8;
        //Save map
        mapp = new MapClass(8, map);
        mpsList.Add(mapp);

        /******************LEVEL 33***************/
        map = CreateEmptyMap(5);
        //start
        map[3, 4] = 2;
        //end
        map[2, 0] = 3;
        //tiles
        map[1, 1] = 6;
        map[3, 1] = 9;
        map[1, 3] = 4;
        map[3, 3] = 4;
        //Save map
        mapp = new MapClass(8, map);
        mpsList.Add(mapp);

        /******************LEVEL 34***************/
        map = CreateEmptyMap(5);
        //start
        map[2, 4] = 2;
        //end
        map[2, 0] = 3;
        //tiles
        map[1, 1] = 7;
        map[2, 1] = 8;
        map[3, 1] = 9;
        map[2, 2] = 6;
        map[2, 3] = 4;
        //Save map
        mapp = new MapClass(8, map);
        mpsList.Add(mapp);

        /******************LEVEL 35***************/
        map = CreateEmptyMap(5);
        //start
        map[1, 4] = 2;
        //end
        map[3, 0] = 3;
        //tiles
        map[1, 1] = 7;
        map[2, 1] = 6;
        map[3, 1] = 8;
        map[1, 2] = 9;
        map[1, 3] = 7;
        map[2, 3] = 8;
        map[3, 3] = 5;
        //Save map
        mapp = new MapClass(8, map);
        mpsList.Add(mapp);

        /******************LEVEL 36***************/
        map = CreateEmptyMap(5);
        //start
        map[3, 4] = 2;
        //end
        map[3, 0] = 3;
        //tiles
        map[2, 1] = 9;
        map[3, 1] = 8;
        map[1, 2] = 5;
        map[2, 2] = 5;
        map[3, 2] = 6;
        map[1, 3] = 7;
        map[3, 3] = 4;
        //Save map
        mapp = new MapClass(8, map);
        mpsList.Add(mapp);

        return mpsList;
    }

    private int[,] CreateEmptyMap(int size)
    {
        int[,] map = new int[size, size];

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                map[x, y] = 1;
            }
        }
        for (int x = 1; x < size - 1; x++)
        {
            for (int y = 1; y < size - 1; y++)
            {
                map[x, y] = 0;
            }
        }
        return map;
    }
}
