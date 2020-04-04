using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    private Transform playerTransform;
    private Vector3 playerPosition;
    public float playerSpeed;
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerPosition = playerTransform.position;
    }

    void Update()
    {
        playerTransform.position = playerPosition;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            playerPosition.x += playerSpeed;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            playerPosition.z += playerSpeed;
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            playerPosition.x -= playerSpeed;
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            playerPosition.z -= playerSpeed;
        }
    }

    
}
