using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    float randX;
    Vector2 whereTospawn;
    public float spawnRate = 0.1f;
    float nextSpawn = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-8.4f, 8.4f);
            whereTospawn = new Vector2(randX, transform.position.y);
            Instantiate(enemy, whereTospawn, Quaternion.identity);
        }
    }
}
