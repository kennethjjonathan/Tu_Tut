using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used for the fire point of the enemy, dequeuing the enemy bullets from the object pool.
// The enemies' bullet will be spawned from the same coordinates with the fire point.

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private new string tag;
    [SerializeField] private float shootTimer;
    private float timer;

    private void Start()
    {
        timer = shootTimer;
    }

    void Shoot()
    {
        ObjectPooler.Instance.SpawnFromPool(tag, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Shoot();
            timer = shootTimer;
        }
    }
}
