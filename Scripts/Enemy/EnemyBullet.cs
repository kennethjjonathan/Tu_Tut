using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used for the enemies' bullets, enqueuing it to the object pool.
public class EnemyBullet : MonoBehaviour, IPooledObject
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private new string tag;

    public void OnObjectSpawn()
    {
        _rb.velocity = -transform.up * _speed;
        StartCoroutine(DeleteBullet());
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(_damage);
        }

        gameObject.SetActive(false);
        ObjectPooler.Instance.poolDictionary[tag].Enqueue(gameObject);

    }

    IEnumerator DeleteBullet()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        ObjectPooler.Instance.poolDictionary[tag].Enqueue(gameObject);
    }
}
