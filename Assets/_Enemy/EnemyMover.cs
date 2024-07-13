using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>(); // Takes the waypoint script and creates a List
    [SerializeField] float waitTime = 1f; // Waiting time for 1 second
    void Start()
    {
        StartCoroutine(FollowPath());
    }
    
    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path) // Looping elements within that list
        {
            // transform.position is nothing but the position of the Enemy.
            transform.position =  waypoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
