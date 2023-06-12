using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float duration = 6f;

    public GameObject pickupEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        FindObjectOfType<AudioManager>().Play("Coin");
        Instantiate(pickupEffect, transform.position, Quaternion.identity);
        
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        player.GetComponent<SpriteRenderer>().color = Color.green;
        Player.maxJumpValue = 2;

        yield return new WaitForSeconds(duration);
        Player.maxJumpValue = 1;
        player.GetComponent<SpriteRenderer>().color = Color.white;
        Destroy(gameObject);
    }
}
