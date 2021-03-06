﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCheck : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<Player>().inPlanet = true;
            player.GetComponent<Player>().planet = gameObject;        
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<Player>().inPlanet = true;
            player.GetComponent<Player>().planet = gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<Player>().inPlanet = false;
            player.GetComponent<Player>().planet = null;
        }
    }
}
