using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            player.GetComponent<Player>().isGrounded = true;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            player.GetComponent<Player>().isGrounded = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        player.GetComponent<Player>().isGrounded = false;
    }
}
