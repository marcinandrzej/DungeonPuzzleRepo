﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    private int xIndex;
    private int yIndex;

    public bool passable;

    public int xExit1;
    public int yExit1;

    public int xExit2;
    public int yExit2;

    public int XIndex
    {
        get
        {
            return xIndex;
        }

        set
        {
            xIndex = value;
        }
    }

    public int YIndex
    {
        get
        {
            return yIndex;
        }

        set
        {
            yIndex = value;
        }
    }

    public void SetPosition(int _xIndex, int _yIndex, Vector3 pos)
    {
        XIndex = _xIndex;
        YIndex = _yIndex;
        transform.localPosition = pos;
    }

    public IEnumerator Move(Vector3 destination, float speed, int _x, int _y)
    {
        XIndex += _x;
        YIndex += _y;
        while (!transform.localPosition.Equals(destination))
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination, speed);
            yield return new WaitForEndOfFrame();
        }
        GameControllerScript.instance.CheckIfEnd();
        yield return new WaitForEndOfFrame();
    }
}
