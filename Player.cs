using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isGrounded = false;
    public bool inPlanet = false;

    public int extraJumpsValue;

    public float speed;
    public float jumpForce;
    public float checkRadius;

    public Transform groundCheck;
    public GameObject planet;

    public LayerMask whatIsGround;

    private int extraJumps;

    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        if (inPlanet)
        {
            jumpForce = 300;
            speed = 6;
            Vector3 targetDir = planet.transform.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 50);
        }
        else
        {
            jumpForce = 50;
            speed = 2;
        }

        if (Input.GetButtonDown("Jump") && extraJumps > 0 && !isGrounded)
        {
            rb.AddForce(transform.up * jumpForce);
            extraJumps--;
        }
        else if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }

    }


    void FixedUpdate()
    {

        moveInput = Input.GetAxis("Horizontal");

        transform.position += (transform.right * moveInput) * (speed/100);


        if (facingRight && moveInput < 0)
        {
            Flip();
        }
        if (!facingRight && moveInput > 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}

