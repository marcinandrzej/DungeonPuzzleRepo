using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllScript : MonoBehaviour
{
    private GameObject activeTile;
    private Vector2 mouseDownCoord;
    private Vector2 mouseUpCoord;
    private Camera mainCamera;
    private int dragMinDistance;

    // Use this for initialization
    void Start ()
    {
        mainCamera = Camera.main;
        dragMinDistance = Mathf.Min(mainCamera.scaledPixelHeight / 5, mainCamera.scaledPixelHeight / 5);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDownCoord = Input.mousePosition;
            RaycastHit hitInfo;
            Ray ray = mainCamera.ScreenPointToRay(mouseDownCoord);
            if (Physics.Raycast(ray, out hitInfo))
            {
                activeTile = hitInfo.collider.gameObject;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (activeTile != null)
            {
                mouseUpCoord = Input.mousePosition;
                if (Vector2.Distance(mouseDownCoord, mouseUpCoord) >= dragMinDistance)
                {
                    TileScript tile = activeTile.GetComponent<TileScript>();
                    int[] deltaxy = CalculateDirection(mouseDownCoord, mouseUpCoord);
                    if (TileManagerScript.instance.CanBeMoved(tile.XIndex + deltaxy[0], tile.YIndex + deltaxy[1]))
                    {
                        TileManagerScript.instance.MoveTile(tile.XIndex, tile.YIndex, deltaxy[0], deltaxy[1], tile);
                    }
                }
                activeTile = null;
            }
        }
        /*
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !end)
        {
            if (isEnabled && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                Vector3 screenPos = Input.mousePosition;
                RaycastHit hitInfo;
                Ray ray = Camera.main.ScreenPointToRay(screenPos);
                if (Physics.Raycast(ray, out hitInfo))
                {
                    Vector3 hP = hitInfo.point;
                    BoxScript box = hitInfo.transform.gameObject.GetComponent<BoxScript>();
                    Play(hP, box);
                }
            }
        }*/
    }

    private int[] CalculateDirection(Vector3 a, Vector3 b)
    {
        int[] xy = new int[2];
        xy[0] = 0;
        xy[1] = 0;
        Vector3 c = b - a;
        float cX = c.x;
        float cY = c.y;
        if (Mathf.Abs(cX) > Mathf.Abs(cY))
        {
            if (cX > 0)
            {
                xy[0] = 1;
            }
            else
            {
                xy[0] = -1;
            }
        }
        else
        {
            if (cY > 0)
            {
                xy[1] = -1;
            }
            else
            {
                xy[1] = 1;
            }
        }
        return xy;
    }
}
