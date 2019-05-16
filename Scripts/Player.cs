using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isGrounded = false;
    public bool inPlanet = false;
    public bool nearRocket = false;
    public bool takingOff = false;
    public bool inSpaceVelocity = false;

    public int extraJumpsValue;

    public float speed;
    public float jumpForce;
    public float checkRadius;

    public Transform groundCheck;
    public GameObject spawnPoint;

    public GameObject planet;
    public GameObject rocket;
    public GameObject bulletPrefab;

    public LayerMask whatIsGround;

    private int extraJumps;

    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;
    private float timer;
    private float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        if (inPlanet)
        {
            inSpaceVelocity = false;
            jumpForce = 300;
            Vector3 targetDir = planet.transform.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle + 90, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 50);

            if (Input.GetButtonDown("Fire1"))
            {
                if (cooldown > 1f)
                {
                    GameObject bullet = Instantiate(bulletPrefab, spawnPoint.transform.position, new Quaternion(spawnPoint.transform.rotation.x, spawnPoint.transform.rotation.y, spawnPoint.transform.rotation.z, spawnPoint.transform.rotation.w));

                    if (!facingRight)
                    {
                        Vector3 scaler = bullet.transform.localScale;
                        scaler.x *= -1;
                        bullet.transform.localScale = scaler;
                    }
                    Destroy(bullet, 5f);
                    cooldown = 0;
                }
            }

            if (Input.GetButton("Run"))
            {
                if (isGrounded)
                {
                    speed = 10;
                }
                else
                {
                    speed = 8;
                }
            }
            else
            {
                if (isGrounded)
                {
                    speed = 6;
                }
                else
                {
                    speed = 4;
                }
            }
        }
        else
        {
            timer += Time.deltaTime;
            jumpForce = 50;
            speed = 0.5f;
            //rb.AddForce(-transform.up * 0.1f);
            rb.AddForce(-rb.velocity * 0.4f);
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

        if (nearRocket)
        {
            if (Input.GetButtonDown("Submit"))
            {
                takingOff = true;
                transform.position = rocket.transform.position;
                transform.SetParent(rocket.transform);
                rocket.GetComponent<Rocket>().takeOff = true;
                rocket.GetComponent<Rocket>().timer = 0;
                gameObject.SetActive(false);
            }
        }
    }

    private GameObject Instantiate(object bulletPrefab, Vector3 vector3)
    {
        throw new NotImplementedException();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");

        transform.position += (transform.right * moveInput) * (speed / 100);


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

