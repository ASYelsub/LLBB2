using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public static GameManager gameManager;
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

        if (Input.GetKey(KeyCode.D))
        {
            playerPosition.x += playerSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            playerPosition.z += playerSpeed;
        }
        if(Input.GetKey(KeyCode.A))
        {
            playerPosition.x -= playerSpeed;
        }
        if(Input.GetKey(KeyCode.S))
        {
            playerPosition.z -= playerSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.GetType());
        //we are trying to set the string in the box of the UI depending on the collision
//        gameManager.DisplayDialogue(1);
    }
}
