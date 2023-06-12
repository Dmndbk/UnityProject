using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpSpeed;
    private Rigidbody2D rb;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask wahtIsGround;
    public bool isGrounded;

    public static int maxJumpValue = 1;
    int maxJump;

    // Start is called before the first frame update
    void Start()
    {
        maxJump = maxJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, wahtIsGround);

        if(Input.GetMouseButtonDown(0) && maxJump > 0)
        {
            maxJump--;
            Jump();
        }
        else if (Input.GetMouseButtonDown(0) && maxJump == 0 && isGrounded)
        {
            Jump();
        }
        if (isGrounded)
        {
            maxJump = maxJumpValue;
        }
        if (isGrounded == false)
        {
            FindObjectOfType<AudioManager>().Play("Land");
        }

    }

    void Jump()
    {
        FindObjectOfType<AudioManager>().Play("Jump");
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0, jumpSpeed));
    }

    
}
