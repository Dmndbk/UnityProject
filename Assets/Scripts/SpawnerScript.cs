using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public float maxTime = 4f;
    public float minTime = 1f;
    private float time;

    public float maxHeigth;
    public float minHeigth;

    public GameObject objectPrefab;
    GameObject obj;

    IEnumerator Start()
    {
        yield return StartCoroutine(Spawn());
        time = 1;
    }

    void Update()
    {
        if (time > maxTime)
        {
            time = 0;
        }
        time += Time.deltaTime;
        Destroy(obj, 6f);
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.5f, maxTime));
            GameObject coin = Instantiate(objectPrefab);
            coin.transform.position = transform.position + new Vector3(0, Random.Range(minHeigth, maxHeigth), 0);
        }
    }
}
