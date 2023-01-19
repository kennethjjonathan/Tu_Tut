using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used to move the enemies randomly.
// The random coordinates are generated by code on line 24.

public class Patrol : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    Vector2 random;
    private float waitTime;
    [SerializeField] private float startWaitTime;


    // Start is called before the first frame update
    void Start()
    {
        random = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, random, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, random) < 0.2f)
        {
            if (waitTime <= 0)
            {
                random = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
