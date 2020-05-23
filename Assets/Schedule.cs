using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Objects", menuName = "Objects/Schedule", order = 1)]
public class Schedule : ScriptableObject
{
    public enum Class { English, Math, Language, Science, None };
    public WeekInSchedule[] weeks;

    public Schedule()
    {
        weeks = new WeekInSchedule[4];
        for (int w = 0; w < weeks.Length; w++)
        {
            weeks[w] = new WeekInSchedule();
        }
    }

    [System.Serializable]
    public class WeekInSchedule
    {
        public DayInSchedule[] daysInSchedule;
        public WeekInSchedule()
        {
            daysInSchedule = new DayInSchedule[7];

            for (int i = 0; i < daysInSchedule.Length; i++)
            {
                daysInSchedule[i] = new DayInSchedule();
                daysInSchedule[i].myDay = (Year.Day)i;
                daysInSchedule[i].timeSlots = new TimeSlot[4];

                for (int j = 0; j < daysInSchedule[i].timeSlots.Length; j++)
                {
                    daysInSchedule[i].timeSlots[j] = new TimeSlot();
                    daysInSchedule[i].timeSlots[j].myTime = (Year.Time)j;
                    daysInSchedule[i].timeSlots[j].myClass = Class.None;

                    switch (j) // for putting some defualt locations/vars
                    {
                        case (1):
                            daysInSchedule[i].timeSlots[j].myClass = Class.English; // not everyone is in this, but everyone is in a class
                            break;
                        case (3):
                            daysInSchedule[i].timeSlots[j].myLocation = LocationManager.location.Dormitory;
                            break;
                    }
                }
            }
        }
    }
        

    public UnityEngine.Vector3 GetCurrentPosition()
    {
        return LocationManager.locationPosition[(int)GetTimeSlot().myLocation];
    }

    public TimeSlot GetTimeSlot()
    {
        return weeks[Year.currentWeek-1].daysInSchedule[(int)Year.currentDay].timeSlots[(int)Year.currentTime];
    }


    [System.Serializable]
    public class TimeSlot
    {
        public Year.Time myTime;
        public LocationManager.location myLocation;
        public Class myClass;

    }

    [System.Serializable]
    public class DayInSchedule
    {
        public Year.Day myDay;
        public TimeSlot[] timeSlots = new TimeSlot[4];
    }


}


