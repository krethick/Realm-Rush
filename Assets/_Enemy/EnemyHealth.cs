using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5; // Enemy's max health point
    [SerializeField] int currentHitPoints = 0; // Current Health Point
    void Start()
    {
        currentHitPoints = maxHitPoints; // setting the max value to current
    }

     void OnParticleCollision(GameObject other) // Create a On ParticelCollison function
    { 
        ProcessHit(); // call the process hit
    }
    
    void ProcessHit()
    {
        currentHitPoints --; // Decrease the point once the enemy gets hit.

        if(currentHitPoints <= 0) // Once the point reaches 0 
        {
            Destroy(gameObject); // Destroy the gameobject(enemy)
        }
    }

}
