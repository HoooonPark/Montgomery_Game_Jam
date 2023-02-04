using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float horizontal;
    public float jumpForce = 5;
    private Rigidbody2D rigidBody;
    private bool isFacingRight;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidBody.AddForce(new Vector2(0, jumpForce));
        }*/
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = rigidBody.position + new Vector2(0.01f, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = rigidBody.position + new Vector2(-0.01f, 0);
        }
      
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }

    }




    bool IsGrounded()
    {
        // Check if the character is touching the ground
        // ...
        return false;
    }
}
