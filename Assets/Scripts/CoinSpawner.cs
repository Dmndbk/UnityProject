using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private float maxTime;
    private float time;

    public float maxHeigth;
    public float minHeigth;

    public GameObject coinPrefab;
    GameObject coin;

    IEnumerator Start()
    {
        yield return StartCoroutine(Spawn());
        time = 1;
    }

    void Update()
    {
        if (time > maxTime)
        {
            //GameObject coin = Instantiate(coinPrefab);
            //coin.transform.position = transform.position + new Vector3(0, Random.Range(minHeigth, maxHeigth), 0);
           
            time = 0;
        }
        time += Time.deltaTime;
        Destroy(coin, 8f);
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 2));
            GameObject coin = Instantiate(coinPrefab);
            coin.transform.position = transform.position + new Vector3(0, Random.Range(minHeigth, maxHeigth), 0);
        }
    }
}
