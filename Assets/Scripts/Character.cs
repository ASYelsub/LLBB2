using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Objects",menuName ="Characters",order = 0)]
public class Character : ScriptableObject
{

    public string _name;

    //STATS
    public int whamitude, popularity, schoolSpirit, 
        creepiness, skinThickness, independence, 
        empathy, strut, health, stamina;

    public int closenessToPlayer;

    public Year.Schedule schedule;

    public Sprite[] characterSprites; //their portraits;

    public LocationManager.location myLocation;

    public GameObject characterOBJ;

    public void ScheduleChanged() // anytime a schedule is changed characters should move to the correct spot based on the current time
    {
        myLocation = (LocationManager.location)schedule.GetTimeSlot().myLocation;
        MovetoPos(schedule.GetCurrentPosition());
    }

    public void MovetoPos(Vector3 pos)
    {
        characterOBJ.transform.position = pos;
    }

    public void SetGameObject(GameObject g) // to help make getting the gameobjects easier
    {
        characterOBJ = g;
    }

}
