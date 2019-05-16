using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float timer = 0;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public Transform player;
    public Transform planet;
    public GameObject planetGO;
    public bool inPlanet = false;
    private bool searchAnotherWay = false;
    private float planetDistance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float distance = (transform.position - player.position).magnitude;

        if (distance < 12)
        {
            if (player.transform.position.x > transform.position.x + 1)
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }

            if (player.transform.position.x < transform.position.x - 1)
            {
                transform.position += -transform.right * speed * Time.deltaTime;
            }
        }

        if (timeBtwShots <=0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
