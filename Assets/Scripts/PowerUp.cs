using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float duration = 4f;
    public float durationCounter;
    private bool powerActive;
    private bool safeMode;

    public GameObject pickupEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        
        Instantiate(pickupEffect, transform.position, Quaternion.identity);

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration); 
        Destroy(gameObject);
    }


}
