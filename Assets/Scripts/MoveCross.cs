using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCross : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float freq = 20;
    public float magnitude = 0.5f;
    private GameManager gm;

    Vector3 pos;
    private Rigidbody2D rb;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        pos = transform.position;
    }

    void Update()
    {
        MoveLeft();
    }
  
    void MoveLeft()
    {
        rb.velocity = Vector3.up * Mathf.Sin(Time.time * freq) * magnitude + Vector3.left * (moveSpeed + gm.speedMultiplier);
    }
}
