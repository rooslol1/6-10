using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;

    public float speedForMeteor = 0f;
    public float spawnSpeed;

    private bool spawnNow = false;

    private float timer;
    private float interval;
    public float distance;

    private GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = (player.transform.position - transform.position).magnitude;
        if (distance > 23)
        {
            timer += Time.deltaTime;
        }

        if (distance <= 23 || distance > 50)
        {
            timer = 0;
        }

        if (timer >= spawnSpeed)
        {
            GameObject meteor = Instantiate(meteorPrefab, new Vector2(transform.position.x + Random.Range(-8, 8), transform.position.y + Random.Range(-8, 8)), transform.rotation);
            meteor.transform.GetChild(0).gameObject.GetComponent<MeteorCheck>().speed = speedForMeteor;
            timer = 0;
        }
    }
}
