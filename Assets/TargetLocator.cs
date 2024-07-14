using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Transform target;
    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform; // Getting the EnemyMover script attached to the enemy
    }

    
    void Update()
    {
        AimWeapon(); // Call the AimWeapon() here.
    }

    void AimWeapon()
    {
       weapon.LookAt(target); // The Ballista Looks at the enemy
    }
}
