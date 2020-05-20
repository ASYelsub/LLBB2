using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
//This script's intent is to track and display where the characters are depending on the TimeManager
//and then send it to the TextHolder on that object.
public class LocationManager : MonoBehaviour
{    
    [SerializeField]
    private Transform[] charTransform = new Transform[7]; //holds the transform of the kid
    public Character[] characters;

    public static Vector3[] locationPosition = new Vector3[25];
    public GameObject[] locations = new GameObject[25];

    public enum location
    {
        LinguaLounge = 0, ScienceLab = 1, TeachersOffice = 2,
        ComputationRoom = 3, WeightRoom = 4, FootballField = 5,
        DarkRoom = 6, TheShed = 7, CostumeCloset = 8,
        PublicTheater = 9, WritingDen = 10, BackField = 11,
        RadioTower = 12, River = 13, SecretGarden = 14,
        BoxingRing = 15, PostOffice = 16, Diner = 17,
        ExtraTerrestrial = 18, Dormitory = 19, WateredMelon = 20,
        TheQuad = 21, TheTrainer = 22, Chapel = 23, ChemicalBasement = 24
    }

    void Start()
    {
        for (int i = 0; i < locations.Length; i++)
        {
            //creates a slot 
            locationPosition[i] = locations[i].transform.position;
        }

        for (int j = 0; j < charTransform.Length - 1;j++)
        {
            characters[j].SetGameObject(charTransform[j].gameObject);
        }

        CharactersMove();
    }



    public void CharactersMove() // called when the time changes
    {
        foreach ( Character c in characters)
        {
            c.ScheduleChanged();
        }
    }

}
