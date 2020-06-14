using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        if (!textManager.isActive)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                playerPosition.x += playerSpeed;
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                playerPosition.z += playerSpeed;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                playerPosition.x -= playerSpeed;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                playerPosition.z -= playerSpeed;
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        GameObject g = collision.gameObject;
        if (g.GetComponent<InteractableBehaviour>() != null)
        {
            Character c = g.GetComponent<InteractableBehaviour>().myCharacter;
            textManager.DisplayLabel(c._name);

            if (Input.GetKeyDown(KeyCode.Space) && !textManager.isActive)
            {
                textManager.label.SetActive(false);
                if (c.weeklyDIalogue[Year.currentWeek - 1].seen)
                {
                    textManager.EnableTextBox(c.weeklyDIalogue[Year.currentWeek - 1].normalDialogue);
                }
                else
                {
                    if (c.schedule.GetTimeSlot().isStoryTime)
                    {
                        c.closenessToPlayer++;
                        if (c.closenessToPlayer > 5)
                        {
                            c.closenessToPlayer = 5;
                        }
                        textManager.EnableTextBox(c.weeklyDIalogue[Year.currentWeek - 1].specialDialogue);
                    }
                    else
                    {
                        textManager.EnableTextBox(c.weeklyDIalogue[Year.currentWeek - 1].normalDialogue);
                    }
                 
                    c.weeklyDIalogue[Year.currentWeek - 1].seen = true;
                }
               
            }
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        textManager.label.SetActive(false);
    }
}
