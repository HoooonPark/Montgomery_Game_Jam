using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform playerTransform; // reference to the player's transform component
    public GameObject player;
    public float cameraSpeed = 7.0f; // speed at which the camera moves
    private Vector3 cameraStartPosition; // starting position of the camera
    private Vector3 tempPos;

    [SerializeField]
    private float minimumDistance, maximumDistance;

    void Start()
    {
        cameraStartPosition = transform.position;
        // player = GameObject.Find("character"); probably don't need this cause we can drop the character object to player variable in Unity
        playerTransform = player.transform;
    }

    void Update()
    {
        // get the horizontal axis input
        float horizontal = Input.GetAxis("Horizontal");

        // move the camera left or right based on arrow key input
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + cameraSpeed * Time.deltaTime, cameraStartPosition.y, cameraStartPosition.z);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - cameraSpeed * Time.deltaTime, cameraStartPosition.y, cameraStartPosition.z);
        }

        // keep the camera following the player's x position
        transform.position = new Vector3(player.transform.position.x, cameraStartPosition.y, cameraStartPosition.z);
    }

    void LateUpdate()
    {
        tempPos = transform.position;
        tempPos.x = playerTransform.position.x;

        if (tempPos.x < minimumDistance)
        {
            tempPos.x = minimumDistance;
        }
        if (tempPos.x > maximumDistance)
        {
            tempPos.x = maximumDistance;
        }

        transform.position = tempPos;
    }
}
