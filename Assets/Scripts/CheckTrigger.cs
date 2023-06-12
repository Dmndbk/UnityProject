using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    public GameObject deathEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Coin")
        {
            FindObjectOfType<AudioManager>().Play("Coin");
            GameManager.instance.AddCoin();
            Destroy(other.gameObject, 0.02f);
        }
        if(other.gameObject.tag == "Wall")
        {
            FindObjectOfType<AudioManager>().Play("GameOver");
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            GameManager.instance.GameOver();
            Destroy(gameObject, 0.02f);
        }
        if (other.gameObject.tag == "Cross")
        {
            FindObjectOfType<AudioManager>().Play("GameOver");
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            GameManager.instance.GameOver();
            Destroy(gameObject, 0.02f);
        }
    }


}
