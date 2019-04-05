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

        Quaternion rot;
        float height = transform.localPosition.y;
        Vector3[] waypoints = new Vector3[path.Count];

        for (int j = 0; j < waypoints.Length; j++)
        {
            waypoints[j] = path[j].gameObject.transform.localPosition;
            waypoints[j].y = height;
            Vector3 destination = waypoints[j];
            rot = Quaternion.LookRotation((waypoints[j] - transform.localPosition), transform.up);

            while (transform.localRotation != rot)
            {
                transform.localRotation = Quaternion.RotateTowards(transform.localRotation, rot, 3.0f);
                yield return new WaitForEndOfFrame();
            }

            while (!transform.localPosition.Equals(destination))
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination, speed);
                yield return new WaitForEndOfFrame();
            }
        }
        GameControllerScript.instance.EndLevel();
        yield return new WaitForEndOfFrame();
    }
}
