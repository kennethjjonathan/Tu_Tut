using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script ended up unused.
// This script is supposed to be used for applying BoxCollider2D to the camera.
// The BoxCollider2D was supposed to be a border to detect the bullets and return them to the object pooler.
// But I figured to just use a timer for the bullets.

public class CalculateCameraBox : MonoBehaviour
{
    private Camera _cam;
    private BoxCollider2D _camBox;
    private float _sizeX, _sizeY, _ratio;

    
    // Start is called before the first frame update
    void Start()
    {
        _cam = GetComponent<Camera>();
        _camBox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _sizeY = _cam.orthographicSize * 2;
        _ratio = (float)Screen.width / (float)Screen.height;
        _sizeX = _sizeY * _ratio;

        _camBox.size = new Vector2(_sizeX, _sizeY);
    }
}
