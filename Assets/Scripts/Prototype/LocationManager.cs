using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
//This script's intent is to track and display where the characters are depending on the TimeManager
//and then send it to the TextHolder on that object.
public class LocationManager : MonoBehaviour
{
    private enum character
    {
        Carnie = 0, Magus = 1, Vesuvius = 2, 
        Carmeline = 3, Elise = 4, Homer = 5,
        Urania = 6, Bobby = 7
    }

    private enum location
    {
        LinguaLounge = 0, ScienceLab = 1, TeachersOffice = 2,
        ComputationRoom = 3, WeightRoom = 4, FootballField= 5,
        DarkRoom = 6, TheShed = 7, CostumeCloset = 8,
        PublicTheater = 9, WritingDen = 10, BackField = 11,
        RadioTower = 12, River = 13, SecretGarden = 14,
        BoxingRing = 15, PostOffice = 16, Diner = 17,
        ExtraTerrestrial = 18, Dormitory = 19, WateredMelon = 20,
        TheQuad = 21, TheTrainer = 22, Chapel = 23, ChemicalBasement = 24
    }
    
    [SerializeField]
    private Transform[] charTransform = new Transform[8]; //holds the transform of the kid
    [SerializeField]
    private GameObject[] locations = new GameObject[25];

    private Vector3[] locationPosition = new Vector3[25];
    void Start()
    {
        charTransform[0].position = locationPosition[TimeManager.dayNumber];
        for (int i = 0; i < locations.Length; i++)
        {
            //creates a slot 
            locationPosition[i] = locations[i].transform.position;
        }
        AssignSpot(TimeManager.dayNumber, TimeManager.weekNumber, TimeManager.timeOfDay);
    }
    
    public void AssignSpot(int dayNum, int weekNum, int timeOfDay) //sets kid positions according to the story
    {
        switch (timeOfDay)
        {
        case 1:
            charTransform[(int) character.Carnie].position = locationPosition[(int) location.LinguaLounge];
            charTransform[(int) character.Vesuvius].position = locationPosition[(int) location.LinguaLounge];
            charTransform[(int) character.Magus].position = locationPosition[(int) location.WritingDen];
            charTransform[(int) character.Bobby].position = locationPosition[(int) location.WritingDen];
            charTransform[(int) character.Urania].position = locationPosition[(int) location.ComputationRoom];
            charTransform[(int) character.Elise].position = locationPosition[(int) location.ComputationRoom];
            charTransform[(int) character.Carmeline].position = locationPosition[(int) location.ScienceLab];
            charTransform[(int) character.Homer].position = locationPosition[(int) location.ScienceLab];
            break;
        case 3:
            charTransform[(int) character.Carnie].position = locationPosition[(int) location.Dormitory];
            charTransform[(int) character.Vesuvius].position = locationPosition[(int) location.Dormitory];
            charTransform[(int) character.Magus].position = locationPosition[(int) location.Dormitory];
            charTransform[(int) character.Bobby].position = locationPosition[(int) location.Dormitory];
            charTransform[(int) character.Urania].position = locationPosition[(int) location.Dormitory];
            charTransform[(int) character.Elise].position = locationPosition[(int) location.Dormitory];
            charTransform[(int) character.Carmeline].position = locationPosition[(int) location.Dormitory];
            charTransform[(int) character.Homer].position = locationPosition[(int) location.Dormitory];
            break;
        default:
                switch (weekNum)
                {
                case 0 :
                   charTransform[(int) character.Carnie].position = locationPosition[(int) location.TheQuad];
                   charTransform[(int) character.Magus].position = locationPosition[(int) location.TheQuad];
                   charTransform[(int) character.Vesuvius].position = locationPosition[(int) location.TheQuad];
                   charTransform[(int) character.Carmeline].position = locationPosition[(int) location.PublicTheater];
                   charTransform[(int) character.Elise].position = locationPosition[(int) location.DarkRoom];
                   charTransform[(int) character.Homer].position = locationPosition[(int) location.SecretGarden];
                   charTransform[(int) character.Urania].position = locationPosition[(int) location.RadioTower];
                   charTransform[(int) character.Bobby].position = locationPosition[(int) location.TheQuad];
                   break;
                case 1 :
                    charTransform[(int) character.Carnie].position = locationPosition[(int) location.LinguaLounge];
                    charTransform[(int) character.Magus].position = locationPosition[(int) location.WeightRoom];
                    charTransform[(int) character.Vesuvius].position = locationPosition[(int) location.LinguaLounge];
                    charTransform[(int) character.Carmeline].position = locationPosition[(int) location.CostumeCloset];
                    charTransform[(int) character.Elise].position = locationPosition[(int) location.PostOffice];
                    charTransform[(int) character.Homer].position = locationPosition[(int) location.SecretGarden];
                    charTransform[(int) character.Urania].position = locationPosition[(int) location.Diner];
                    charTransform[(int) character.Bobby].position = locationPosition[(int) location.WeightRoom];
                    break;
                case 2 :
                    charTransform[(int) character.Carnie].position = locationPosition[(int) location.WeightRoom];
                    charTransform[(int) character.Magus].position = locationPosition[(int) location.TheTrainer];
                    charTransform[(int) character.Vesuvius].position = locationPosition[(int) location.ExtraTerrestrial];
                    charTransform[(int) character.Carmeline].position = locationPosition[(int) location.PublicTheater];
                    charTransform[(int) character.Elise].position = locationPosition[(int) location.River];
                    charTransform[(int) character.Homer].position = locationPosition[(int) location.PublicTheater];
                    charTransform[(int) character.Urania].position = locationPosition[(int) location.River];
                    charTransform[(int) character.Bobby].position = locationPosition[(int) location.FootballField];
                    break;
                case 3 :
                    charTransform[(int) character.Carnie].position = locationPosition[(int) location.BoxingRing];
                    charTransform[(int) character.Magus].position = locationPosition[(int) location.River];
                    charTransform[(int) character.Vesuvius].position = locationPosition[(int) location.WateredMelon];
                    charTransform[(int) character.Carmeline].position = locationPosition[(int) location.ScienceLab];
                    charTransform[(int) character.Elise].position = locationPosition[(int) location.River];
                    charTransform[(int) character.Homer].position = locationPosition[(int) location.River];
                    charTransform[(int) character.Urania].position = locationPosition[(int) location.TeachersOffice];
                    charTransform[(int) character.Bobby].position = locationPosition[(int) location.WeightRoom];
                    break;
                case 4 :
                    break;
                case 5 :
                    break;
                case 6 :
                    break;
                case 7 :
                    break;
                case 8 :
                    break;
                }
            break;
        }
       
        
        
    }


}
