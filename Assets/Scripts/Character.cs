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
    public WeeklyDialogue[] weeklies; // need a better name for this. It's an array because there's multiple weeks etc.

    public void ScheduleChanged(GameObject g) // anytime a schedule is changed characters should move to the correct spot based on the current time
    {
        myLocation = (LocationManager.location)schedule.GetTimeSlot().myLocation;
        MovetoPos(g,schedule.GetCurrentPosition());
    }

    public void MovetoPos(GameObject g,Vector3 pos)
    {
        g.transform.position = pos;
    }

    [System.Serializable]
    public class WeeklyDialogue
    {
        public string[] dialogue;
        public string[] shorterDialogue; // to be displayed when the dialogue for the week has already been seen
        public bool isSpecial;
        public bool seen; // did we see this converstaion already?
    }

}
