using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Although this script is called TextHolder, it does not hold text, it displays text according to what character is currently
//at the location this script is on.

public class TextHolder : MonoBehaviour
{
    [SerializeField]
    private string[] dialogue = new string[20];
    public GameManager gameManager;
    [SerializeField] private MeshRenderer notifCube;

    [SerializeField]
    private Button[] charSelectDialogueButton = new Button[5];

    private void Start()
    {
        notifCube.enabled = false;
    }

    private void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space))
        {
            gameManager.DisplayDialogue(dialogue[0]);
            notifCube.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        notifCube.enabled = false;
        gameManager.TurnOffDialogue();
    }

    public void LinguaLoungeButtons(string charName1, string charName2, string charName3, string charName4)
    {
        
    }
}
