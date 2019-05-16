using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCheck : MonoBehaviour
{
    public float speed = 0;

    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().inPlanet = true;
            collision.GetComponent<Player>().planet = gameObject;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().inPlanet = true;
            collision.GetComponent<Player>().planet = gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().inPlanet = false;
            collision.GetComponent<Player>().planet = null;
        }
    }

    void Update()
    {
        transform.parent.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
        transform.parent.Rotate(0, 0, 1);
    }
}
