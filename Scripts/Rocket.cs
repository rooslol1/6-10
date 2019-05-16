using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 3;
    public float timer = 0;

    public bool takeOff = false;

    public GameObject player;
    private float moveInput;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<Player>().rocket = gameObject;
            col.GetComponent<Player>().nearRocket = true;
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<Player>().rocket = gameObject;
            col.GetComponent<Player>().nearRocket = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<Player>().rocket = null;
            col.GetComponent<Player>().nearRocket = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        player.SetActive(true);
        player.GetComponent<Player>().takingOff = false;
        player.transform.parent = null;
        Destroy(gameObject);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (takeOff)
        {
            if (timer >= 1)
            {
                speed = 1f;
            }

            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

    void FixedUpdate()
    {
        if (takeOff)
        {
            moveInput = Input.GetAxis("Horizontal");

            transform.Rotate(0,0, 0.5f * -moveInput);
        }
    }
}

