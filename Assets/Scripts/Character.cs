using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Objects",menuName ="Characters",order = 0)]
public class Character : ScriptableObject
{

    public string _name;

    //STATS
    public int whamitude, popularity, school, spirit, 
        creepiness, skinThickness, independence, 
        empathy, strut, health, stamina;

    public int closenessToPlayer;

    public Year.Schedule schedule;

    public Year.location myLocation;

    public Sprite[] characterSprites; //their portraits;

    public GameObject characterOBJ;

    public void ScheduleChanged() // anytime a schedule is changed characters should move to the correct spot based on the current time
    {
        MovetoPos( Year.locations[schedule.daysInSchedule[(int)Year.currentDay].timeSlots[(int)Year.currentTime].myPos]);
        // the above looks really ugly and complex for no reason :/ need to fix tomorrow
    }

    public void MovetoPos(Vector3 pos)
    {
        characterOBJ.transform.position = pos;
    }

}
