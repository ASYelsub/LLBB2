using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextHolder : MonoBehaviour
{
    public string dialogue;
    public GameManager gameManager;
    
    
    private void OnTriggerEnter(Collider other)
    {
        print(other.name );
        gameManager.DisplayDialogue(dialogue);
    }
}
