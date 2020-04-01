using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextHolder : MonoBehaviour
{
    [SerializeField]
    private Text dialogueText;
    [SerializeField]
    private string dialogue;
    void Start()
    {
        //dialogueText.text = dialogue;
    }

    void DisplayText()
    {
        dialogueText.text = dialogue;
    }
}
