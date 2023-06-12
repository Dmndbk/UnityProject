using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    private float maxTime;
    private float time;

    public float maxHeigth;
    public float minHeigth;

    public GameObject wallPrefab;
    GameObject wall;

    IEnumerator Start()
    {
        yield return StartCoroutine(Spawn());
        time = 1;
    }

    void Update()
    {
        if(time > maxTime)
        {
            //GameObject wall = Instantiate(wallPrefab);
            //wall.transform.position = transform.position + new Vector3(0, Random.Range(minHeigth, maxHeigth), 0);
            
            time = 0;
        }
        time += Time.deltaTime;
        Destroy(wall, 6f);
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.5f, 4));
            GameObject coin = Instantiate(wallPrefab);
            coin.transform.position = transform.position + new Vector3(0, Random.Range(minHeigth, maxHeigth), 0);
        }
    }
}
