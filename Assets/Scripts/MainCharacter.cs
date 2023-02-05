using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float horizontal;
    public float jumpForce = 10f;
    private Rigidbody2D rigidBody;
    private bool isFacingRight;
    private Animator animator;
    private string WALK = "Walk";
    private float maxDist = 23.5f;
    private float minDist = -12;

    [SerializeField]
    private float speed;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidBody.AddForce(new Vector2(0, jumpForce));
        }*/
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < maxDist)
            {
                transform.position = rigidBody.position + new Vector2(speed, 0);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > minDist)
            {
                transform.position = rigidBody.position + new Vector2(-speed, 0);
            }
        }
      
        horizontal = Input.GetAxis("Horizontal");

        // Set animation condition (Walking, Idling)
        if (horizontal != 0) {
            animator.SetBool(WALK, true);
        }
        else {
            animator.SetBool(WALK, false);
        }

        // Flip the character
        if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }

        // If user press space and the character is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

    }


    bool IsGrounded()
    {
        var val = Convert.ToString(rigidBody.transform.position.y);
        return rigidBody.transform.position.y < -2.01f;    
    }
}
