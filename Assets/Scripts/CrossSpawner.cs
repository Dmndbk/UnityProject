using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossSpawner : MonoBehaviour
{
    private float maxTime;
    private float time;

    public float maxHeigth;
    public float minHeigth;

    public GameObject crossPrefab;
    GameObject cross;

    IEnumerator Start()
    {
        yield return StartCoroutine(Spawn());
        time = 1;
    }

    void Update()
    {
        if (time > maxTime)
        {

            //GameObject cross = Instantiate(crossPrefab);
            //cross.transform.position = transform.position + new Vector3(0, Random.Range(minHeigth, maxHeigth), 0);
            
            time = 0;
        }
        time += Time.deltaTime;
        Destroy(cross, 6f);
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            GameObject coin = Instantiate(crossPrefab);
            coin.transform.position = transform.position + new Vector3(0, Random.Range(minHeigth, maxHeigth), 0);
        }
    }
}
