using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public Rigidbody2D rb;
    public Transform groundCheckBase;
    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public Transform groundCheckTop;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsBounce;
    private bool onGround;
    private bool onBounce;

    public GameObject trail;
    public static bool TrailIsOn;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trail = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(5, rb.velocity.y);
        onGround = Physics2D.OverlapCircle(groundCheckBase.position, groundCheckRadius, whatIsGround) || Physics2D.OverlapCircle(groundCheckLeft.position, groundCheckRadius, whatIsGround) || Physics2D.OverlapCircle(groundCheckRight.position, groundCheckRadius, whatIsGround) || Physics2D.OverlapCircle(groundCheckTop.position, groundCheckRadius, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, 4);
        }

        onBounce = Physics2D.OverlapCircle(groundCheckBase.position, groundCheckRadius, whatIsBounce) || Physics2D.OverlapCircle(groundCheckLeft.position, groundCheckRadius, whatIsBounce) || Physics2D.OverlapCircle(groundCheckRight.position, groundCheckRadius, whatIsBounce) || Physics2D.OverlapCircle(groundCheckTop.position, groundCheckRadius, whatIsBounce);

        if (Input.GetKeyDown(KeyCode.Space) && onBounce)
        {
            rb.velocity = new Vector2(rb.velocity.x, 20);
        }
    }

    public void toggleTrail()
    {
        if (TrailIsOn)
        {
            trail.SetActive(false);
            TrailIsOn = false;
        } else {
            trail.SetActive(true);
            TrailIsOn = true;
        }
        
    }
}
