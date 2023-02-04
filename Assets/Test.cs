using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float jumpForce = 5;
    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rigidBody.AddForce(new Vector2(0, jumpForce));
        }*/
        if (Input.anyKey)
        {
            transform.position = rigidBody.position + new Vector2(2, 0);
        }

    }

    bool IsGrounded()
    {
        // Check if the character is touching the ground
        // ...
        return false;
    }
}
