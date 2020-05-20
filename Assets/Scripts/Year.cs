using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[System.Serializable]
public static class Year
{
    public static Month[] months;
    public static int currentYear, currentMonth;
    public static Day currentDay;
    public static Time currentTime;

    public enum Time { Morning, Class, Afternoon, Evening };
    public enum Day { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
    public enum WhichMonth { January = 1, February, March, April, May, June, July, August, September, October, November, December };
    public enum Class { English, Math, Language, Science, };

    public class Schedule
    {
        public DayInSchedule[] daysInSchedule; // should be 7
        public UnityEngine.Vector3 GetCurrentPosition()
        {
            return LocationManager.locationPosition[GetTimeSlot().myLocation];
        }

        public TimeSlot GetTimeSlot()
        {
            return daysInSchedule[(int)currentDay].timeSlots[(int)currentTime];
        }
    }

    public class TimeSlot
    {
        public Time myTime;
        public int myLocation;
        public Class myClass;

    }

    [System.Serializable]
    public class DayInSchedule
    {
        public Day myDay;
        public TimeSlot[] timeSlots;
    }

    [System.Serializable]
    public class Month
    {
        public int currentWeek;
        public WhichMonth month;
        public int dayInMonth; //ranging from 1-31

        public string GetCurrentMonth()
        {
            return month.ToString();
        }
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

    public static string GetShortDate()
    {
        return currentMonth + "/" + GetDayInMonth();
    }

    public static int GetDayInMonth()
    {
        return months[currentMonth].dayInMonth;
    }


    public static void SetDayInMonth(int i)
    {
        months[currentMonth].currentWeek = i;
    }

    public static int GetWeekInMonth()
    {
        return months[currentMonth].currentWeek;
    }
    
    static void NextWeek()
    {
        months[currentMonth].currentWeek++;
        currentDay = 0;
    }

    static void NextDay()
    {
        months[currentMonth].dayInMonth++;
        currentTime = 0;
    }

    static void NextMonth()
    {
        SetDayInMonth(1);
        currentMonth++;
    }

    public static void GoToNextWeek() // might want to change how this works tbh
    {
        if (GetWeekInMonth() >= 4)
        {
            SetWeekInMonth(0);
        }
        else
        {
            NextWeek();
        }
    }


    public static void GoToNextDay() //goes to next day, sets timeOfDay to 1, adds to dayNumber and adds or resets monthCount
    {
        if (GetDayInMonth() >= 6)
        {
            NextWeek();
        }
        else
        {
            NextDay();
        }


        if (currentMonth == 0 && GetDayInMonth() >= 31) //we want it to check dayPerMonthCount before changing it.
        {
            NextMonth();
        }
        else if (currentMonth == 1)
        {
            if(currentYear % 4 == 0 && GetDayInMonth() >= 29)
            {
                NextMonth();
            }
            else if (currentYear % 4 != 0 && GetDayInMonth() >= 28)
            {
                NextMonth();
            }
        }
        else if (currentMonth == 2 && GetDayInMonth() >= 31)
        {
            NextMonth();
        }
        else if (currentMonth == 3 && GetDayInMonth() >= 30)
        {
            NextMonth();
        }
        else if (currentMonth == 4 && GetDayInMonth() >= 31)
        {
            NextMonth();
        }
        else if (currentMonth == 5 && GetDayInMonth() >= 30)
        {
            NextMonth();
        }
        else if (currentMonth == 6 && GetDayInMonth() >= 31)
        {
            NextMonth();
        }
        else if (currentMonth == 7 && GetDayInMonth() >= 31)
        {
            NextMonth();
        }
        else if (currentMonth == 8 && GetDayInMonth() >= 30)
        {
            NextMonth();
        }
        else if (currentMonth == 9 && GetDayInMonth() >= 31)
        {
            NextMonth();
        }
        else if (currentMonth == 10 && GetDayInMonth() >= 30)
        {
            NextMonth();
        }
        else if (currentMonth == 11 && GetDayInMonth() >= 31)
        {
            NextMonth();
        }
    }

    public static void SetWeekInMonth(int i)
    {
        months[currentMonth].dayInMonth = i;
    }
   
}
