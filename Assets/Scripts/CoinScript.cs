using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameObject pickupEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    public void Pickup()
    {
        GameManager.instance.AddCoin();
        FindObjectOfType<AudioManager>().Play("Coin");
        Instantiate(pickupEffect, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.02f);
    }


}
