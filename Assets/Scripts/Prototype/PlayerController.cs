using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    TextManager textManager;
    private Transform playerTransform;
    private Vector3 playerPosition;
    public float playerSpeed;
    void Start()
    {
        textManager = FindObjectOfType<TextManager>();
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

    private void OnCollisionStay(Collision collision)
    {
        GameObject g = collision.gameObject;
        Debug.Log(g.name);
        if (g.GetComponent<InteractableBehaviour>() != null)
        {
            Character c = g.GetComponent<InteractableBehaviour>().myCharacter;
            textManager.DisplayLabel(c._name);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                textManager.label.SetActive(false);
                if (c.weeklies[Year.currentWeek].seen)
                {
                    textManager.EnableTextBox(c.weeklies[Year.currentWeek].shorterDialogue);
                }
                else
                {
                    if (c.weeklies[Year.currentWeek].isSpecial)
                    {
                        c.closenessToPlayer++;
                        if (c.closenessToPlayer > 5)
                        {
                            c.closenessToPlayer = 5;
                        }
                    }
                    textManager.EnableTextBox(c.weeklies[Year.currentWeek].dialogue);
                    c.weeklies[Year.currentWeek].seen = true;
                }
               
            }
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        textManager.label.SetActive(false);
    }
}
