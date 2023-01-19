using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used for the players bullet, enqueuing to the object pool.

public class Bullet : MonoBehaviour, IPooledObject
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private Rigidbody2D rb;

    
    // Start is called before the first frame update
    public void OnObjectSpawn()
    {
        rb.velocity = transform.up * speed;
        StartCoroutine(DeleteBullet());
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.ForDamageAnimation();
            enemy.TakeDamage(damage);
        }

        gameObject.SetActive(false);
        ObjectPooler.Instance.poolDictionary["Bullet"].Enqueue(gameObject);

    }

    IEnumerator DeleteBullet()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        ObjectPooler.Instance.poolDictionary["Bullet"].Enqueue(gameObject);
    }
}
