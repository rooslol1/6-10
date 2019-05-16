using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float timer;
    public float distance;

    public GameObject player;

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Rocket")
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");

            distance = (player.transform.position - transform.position).magnitude;

            if (distance > 15)
            {
                timer += Time.deltaTime;

                if (timer >= 30)
                {
                    Destroy(gameObject);
                }
            }

            if (distance <= 15)
            {
                timer = 0;
            }
        }
    }
}
