using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>(); // Takes the waypoint script and creates a List
    [SerializeField] [Range(0f,5f)] float speed = 1f; // use range amd Waiting time for speed at 1 second
    
    void Start()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }
    
    void FindPath()
    {

        path.Clear(); // Clear the path more like system.cls
        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in parent.transform)
        {
            // Adding the waypoints as we get contents from the WayPoint script
            path.Add(child.GetComponent<Waypoint>()); // We are inserting into the list
        }
    }

    void ReturnToStart() // Move our enemy to the first waypoint
    {
          transform.position = path[0].transform.position;
    }
    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path) // Looping elements within that list
        {
            Vector3 startposition = transform.position;  // Starting Position
            Vector3 endPosition = waypoint.transform.position; // Ending Position
            float travelPercent = 0f; // travel percent
            
            transform.LookAt(endPosition);

            while(travelPercent < 1f) // We are not the end position
            {
            
            travelPercent += Time.deltaTime * speed;
            
            transform.position = Vector3.Lerp(startposition, endPosition,travelPercent);
            
            /*
              IMPORTANT COMMENTING JUST FOR A MOMENT
            float jumpHeight = Mathf.Sin(travelPercent * Mathf.PI) * 2; // Related to the ossilation concept in Project boost
            Vector3 jumpPosition = new Vector3(transform.position.x, transform.position.y +  jumpHeight,transform.position.z); // change the vector position
            transform.position = jumpPosition;
           */

            yield return new WaitForEndOfFrame(); // End of the frame is completed
            }          
        }

        Destroy(gameObject);
    }
}
