using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>(); // Takes the waypoint script and creates a List
    [SerializeField] [Range(0f,5f)] float speed = 1f; // use range amd Waiting time for speed at 1 second
    void Start()
    {
        StartCoroutine(FollowPath());
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
            yield return new WaitForEndOfFrame(); // End of the frame is completed
            }
            
        }
    }
}
