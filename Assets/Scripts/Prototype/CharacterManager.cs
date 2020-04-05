using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script's intent is to track and display where the characters are depending on the TimeManager
//and then send it to the TextHolder on that object.
public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] KidTransform = new Transform[8]; //holds the transform of the kid
    [SerializeField]
    private Vector3[] TeacherSpot = new Vector3[2];
    [SerializeField]
    private GameObject[] Locations = new GameObject[20];
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
