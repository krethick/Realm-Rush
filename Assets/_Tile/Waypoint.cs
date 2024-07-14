using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isPlacable;

    private Transform placement; // Object Placement
    void OnMouseDown() {
        if(isPlacable)
        {
        placement = this.transform;
        // Game object, position placement, keep the rotation as the same
        Instantiate(towerPrefab, placement.position, Quaternion.identity);
        isPlacable = false; // Once object is placed set it as false
        }
    }
}
