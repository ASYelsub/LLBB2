using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class Year
{
    public static Month[] months;
    public static int currentYear, currentMonth;
    public static Day currentDay;
    public static Time currentTime;

    public static Vector3[] locations;
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

    public static string GetDateAsString()
    {
        return currentDay + ", " + months[currentMonth].GetCurrentMonth() + " " + months[currentMonth].dayInMonth + ", " + currentYear;
    }

    public static int GetDateAsInt()
    {
        string s = currentMonth + months[currentMonth].dayInMonth.ToString() + currentYear;
        return int.Parse(s);
    }

  

    public class Schedule
    {
        public DayInSchedule[] daysInSchedule; // should be 7
    }

    public class TimeSlot
    {
        public Time myTime;
        public int myLocation, myPos; // ints are used to find the location and locationPos
    }

    [System.Serializable]
    public class DayInSchedule
    {
        public Day myDay;
        public TimeSlot[] timeSlots;
    }

    public enum Time { Morning, Class, Afternoon, Evening };
    public enum Day { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
    public enum WhichMonth {  January = 1, February, March, April, May, June, July, August, September, October, November, December};

    [System.Serializable]
    public class Month
    {
        public int numOfWeeks; // how many weeks are in this month:
        public WhichMonth month;
        public int dayInMonth; //ranging from 1-31

        public string GetCurrentMonth()
        {
            return month.ToString();
        }
    }
   
}
