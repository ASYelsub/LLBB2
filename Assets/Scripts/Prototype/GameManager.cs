using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] placesAffected = new GameObject[2];
    [SerializeField]
    private string[] textPlaces = new String[2];
    [SerializeField]
    private Text dialogueText;
    
    /*public enum PlaceNames
    {
        LinguaLounge,
        ScienceLab
    };*/
    
    

    void Start()
    {
        /*Dictionary<PlaceNames, int> placeDict = new Dictionary<PlaceNames, int>();
        placeDict.Add(PlaceNames.LinguaLounge, 0);
        placeDict.Add(PlaceNames.ScienceLab, 1);
        foreach (KeyValuePair<PlaceNames,int> pair in placeDict)
        {
            print(pair.Key + "" + pair.Value);
        }*/
        
    }

    void Update()
    {
        
    }

    public void DisplayDialogue(string dialogue) //trying to set the text object that will be displaying
         {
             dialogueText.text = dialogue;
         }
}
