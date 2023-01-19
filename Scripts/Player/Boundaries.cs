using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used to make sure the player doesn't go out of bounds from the camera.

public class Boundaries : MonoBehaviour
{
    private Vector3 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().size.y / 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}