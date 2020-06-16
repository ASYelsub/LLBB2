using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Objects",menuName ="Objects/Characters",order = 0)]
public class Character : ScriptableObject
{

    public string _name;

    [System.Serializable]
    public class Stats
    {
        public enum Stat
        {
            whamitude, popularity, schoolSpirit,
            creepiness, skinThickness, independence,
            empathy, strut, health, stamina
        };

        public Stat stat;
        public int _amt;
    }

    public Stats[] myStats;

    public int closenessToPlayer;

    public Schedule charSchedule; // their specific schedule
    public Schedule schedule; // their current schedule that's being used

    public Sprite[] characterSprites; //their portraits;

    public LocationManager.location myLocation;
    public WeeklyDialogue[] weeklyDIalogue; // need a better name for this. It's an array because there's multiple weeks etc.

    public WearableItem[] wearableItems;
    public SkillTree skillTree;

    public Character()
    {
        schedule = charSchedule; // by default their default schedule is their specific schedule
    }

    public void ScheduleChanged(GameObject g) // anytime a schedule is changed characters should move to the correct spot based on the current time
    {
        if(schedule.weeks.Count < Year.currentWeek)
        {
            Debug.Log(_name + " is unable to move because there's not enough weeks in their schedule!"); // current week is greater than the weeks in their sche
        }
        else
        {
            myLocation = schedule.GetTimeSlot().myLocation;
            MovetoPos(g, schedule.GetCurrentPosition());
        }
    }

    public void MovetoPos(GameObject g,Vector3 pos)
    {
        g.transform.position = pos;
    }

    public void ChangeSchedule(Schedule s)
    {
        schedule = s;
    }

    [System.Serializable]
    public class WeeklyDialogue
    {
        public string[] specialDialogue;
        public string[] afterSpecialDialogue;
        public string[] normalDialogue;
        public bool seen; // did we see this converstaion already?
    }

    public void ChangeStats(Stats.Stat s, int amt)
    {
        FindStat(s)._amt += amt;
    }


    public Stats FindStat(Stats.Stat s)
    {
        foreach(Stats stat in myStats)
        {
            if(stat.stat == s)
            {
                return stat;
            }
        }
        Debug.LogError("Couldn't find matching stat");
        return null;
    }
}
