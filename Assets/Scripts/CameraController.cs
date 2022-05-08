using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject playerSprite;
    private Vector3 offset;
    public Rigidbody2D rb;
    public Camera cam;
    // public bool timeDelay;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerSprite.transform.position;
        cam = GetComponent<Camera>();
        rb = playerSprite.GetComponent<Rigidbody2D>();
        
        cam.orthographicSize = 5;
        // cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerSprite.transform.position + offset;
        if ((rb.velocity.y > 0.5 || rb.velocity.y < -0.5) && cam.orthographicSize < 10)
        {
            // cam.orthographicSize = 10;
        }
        else if (cam.orthographicSize > 5)
        {
            // cam.orthographicSize = 5;
        }
    }
}
