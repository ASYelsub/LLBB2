using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

[System.Serializable]
public static class Year
{
    public static WhichMonth currentMonth;
    public static int currentYear, currentWeek, dayInMonth;
    public static Day currentDay;
    public static Time currentTime;

    public enum Time { Morning, Class, Afternoon, Evening };
    public enum Day { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
    public enum WhichMonth { January = 1, February, March, April, May, June, July, August, September, October, November, December };
   
    public static string GetDateAsString()
    {
        return currentDay + ", " + currentMonth.ToString() + " " + dayInMonth + ", " + currentYear;
    }

    public static int GetDateAsInt()
    {
        string s = (currentMonth+1) + dayInMonth.ToString() + currentYear;
        return int.Parse(s);
    }

    public static string GetShortDate()
    {
        return currentMonth.ToString() + "/" + dayInMonth;
    }

    public static void XDaysLater(int numDays)
    {
        for (int i = 0; i < numDays; i++) 
            GoToNextDay();
    }

    public static void GoToNextWeek() // might want to change how this works tbh
    {
        currentDay = 0;
        currentWeek++;

    }
    public static void GoToNextMonth()
    {
        dayInMonth = 1;
        currentMonth++;
    }


    public static void GoToNextDay() //goes to next day, sets timeOfDay to 1, adds to dayNumber and adds or resets monthCount
    {
        dayInMonth++;
        if ((int)currentDay >= 6)
        {
            GoToNextWeek();
        }
        else
        {
            currentTime = 0;
            currentDay++;
        }

        if (dayInMonth >= 28)
        {
            CheckDayInMonth();
        }
    }

    static void CheckDayInMonth() // checking if we're not going to a day in the month that doesn't exist
    {

        if (currentMonth == 0 && dayInMonth >= 31) //we want it to check dayPerMonthCount before changing it.
        {
            GoToNextMonth();
        }
        else if ((int)currentMonth == 1)
        {
            if (currentYear % 4 == 0 && dayInMonth >= 29)
            {
                GoToNextMonth();
            }
            else if (currentYear % 4 != 0 && dayInMonth >= 28)
            {
                GoToNextMonth();
            }
        }
        else if ((int)currentMonth == 2 && dayInMonth >= 31)
        {
            GoToNextMonth();
        }
        else if ((int)currentMonth == 3 && dayInMonth >= 30)
        {
            GoToNextMonth();
        }
        else if ((int)currentMonth == 4 && dayInMonth >= 31)
        {
            GoToNextMonth();
        }
        else if ((int)currentMonth == 5 && dayInMonth >= 30)
        {
            GoToNextMonth();
        }
        else if ((int)currentMonth == 6 && dayInMonth >= 31)
        {
            GoToNextMonth();
        }
        else if ((int)currentMonth == 7 && dayInMonth >= 31)
        {
            GoToNextMonth();
        }
        else if ((int)currentMonth == 8 && dayInMonth >= 30)
        {
            GoToNextMonth();
        }
        else if ((int)currentMonth == 9 && dayInMonth >= 31)
        {
            GoToNextMonth();
        }
        else if ((int)currentMonth == 10 && dayInMonth >= 30)
        {
            GoToNextMonth();
        }
        else if ((int)currentMonth == 11 && dayInMonth >= 31)
        {
            GoToNextMonth();
        }
    }

   
}
