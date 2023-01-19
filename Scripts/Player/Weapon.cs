using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is for the player's fire point, dequeuing the bullets from the object pool.

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    private void Shoot()
    {
        ObjectPooler.Instance.SpawnFromPool("Bullet", transform.position, Quaternion.identity);
    }
    
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
}
