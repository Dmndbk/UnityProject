using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTailEffect : MonoBehaviour
{
    public float startTimeBtwSpawn;
    float timeBtwSpawn;
    public GameObject tailPrefab;

    

    // Update is called once per frame
    void Update()
    {
        if(timeBtwSpawn <= 0)
        {
            GameObject tail = Instantiate(tailPrefab, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            Destroy(tail, 3f);
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
