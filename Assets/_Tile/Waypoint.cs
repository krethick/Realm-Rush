using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get{ return isPlaceable; }} // this is a period (similar to getter)

      private Transform placement; // Object Placement
    void OnMouseDown() 
    {
     if(isPlaceable)
     {
         placement = this.transform;
         // Game object, position placement, keep the rotation as the same
         Instantiate(towerPrefab, placement.position, Quaternion.identity);
         isPlaceable = false; // Once object is placed set it as false
     }
    }
}
