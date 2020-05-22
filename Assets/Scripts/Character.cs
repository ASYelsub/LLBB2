using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Objects",menuName ="Objects/Characters",order = 0)]
public class Character : ScriptableObject
{

    public string _name;

    //STATS
    public int whamitude, popularity, schoolSpirit, 
        creepiness, skinThickness, independence, 
        empathy, strut, health, stamina;

    public int closenessToPlayer;

    public Schedule schedule;

    public Sprite[] characterSprites; //their portraits;

    public LocationManager.location myLocation;

    public void ScheduleChanged(GameObject g) // anytime a schedule is changed characters should move to the correct spot based on the current time
    {
        myLocation = (LocationManager.location)schedule.GetTimeSlot().myLocation;
        MovetoPos(g,schedule.GetCurrentPosition());
    }

    public void MovetoPos(GameObject g,Vector3 pos)
    {
        g.transform.position = pos;
    }
}
