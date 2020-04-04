using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    //public static int dayCount = 0;
    [SerializeField]
    private Text dialogueText;
    [SerializeField] private GameObject textBox;
   
    void Start()
    {
        textBox.SetActive(false);
    }
    
    public void DisplayDialogue(string dialogue)
    {
        dialogueText.text = dialogue;
        textBox.SetActive(true);
    }

    public void TurnOffDialogue()
    {
        textBox.SetActive(false);
    }
}
