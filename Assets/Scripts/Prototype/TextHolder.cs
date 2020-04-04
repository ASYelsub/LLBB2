using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextHolder : MonoBehaviour
{
    private string[] dialogue = new string[20];
    public GameManager gameManager;
    public bool isColliding;
    [SerializeField] private MeshRenderer notifCube;

    private void Start()
    {
        isColliding = false;
        notifCube.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space))
        {
            if (isColliding)
            {
                gameManager.DisplayDialogue(dialogue[0]);
                notifCube.enabled = true;
            }
            else
            {
                notifCube.enabled = false;
            }
        }
        //print(isColliding);
    }

    private void OnTriggerEnter(Collider other)
    {
        isColliding = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isColliding = false;
        notifCube.enabled = false;
        gameManager.TurnOffDialogue();
    }
}
