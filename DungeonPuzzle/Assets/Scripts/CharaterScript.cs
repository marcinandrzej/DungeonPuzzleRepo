using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterScript : MonoBehaviour
{
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator Move (List<TileScript> path, float speed)
    {
        float height = transform.localPosition.y;
        Vector3[] waypoints = new Vector3[path.Count];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = path[i].gameObject.transform.localPosition;
            waypoints[i].y = height;
        }

        for (int j = 0; j < waypoints.Length; j++)
        {
            Vector3 destination = waypoints[j];
            while (!transform.localPosition.Equals(destination))
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination, speed);
                yield return new WaitForEndOfFrame();
            }
        }
        yield return new WaitForEndOfFrame();
    }
}
