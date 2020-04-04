using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static int timeOfDay; //1 = before class, //1 = during class, //2 = after class, //3 = evening
    public static int dayNumber; //starts the week of August 26th, never resets
    public static int dayPerMonthCount; //every time monthCount gets to maximum number of days in given month, the string associated with the month name changes and monthCount sets to 1
    public static string[] monthName = new string[13]; //name of the month displayed
    private int monthToken; //goes in monthCount

    [SerializeField] private Text monthDisplay;
    [SerializeField] private Text dayDisplay;
    [SerializeField] private Text timeOfDayDisplay;
    
    
    void Start() //these setters will be erased and probably put on the gameManager.
    {
        monthName[0] = "January";
        monthName[1] = "Februray";
        monthName[2] = "March";
        monthName[3] = "April";
        monthName[4] = "May";
        monthName[5] = "June";
        monthName[6] = "July";
        monthName[7] = "August";
        monthName[8] = "September";
        monthName[9] = "October";
        monthName[10] = "November";
        monthName[11] = "December";

        monthToken = 7; //starts in August
        
        timeOfDay = 1;
        
        dayPerMonthCount = 1;
        monthDisplay.text = "Month: " + monthName[monthToken];
        dayDisplay.text = "Day: " + dayPerMonthCount.ToString();
        timeOfDayDisplay.text = "Time of Day: " + timeOfDay.ToString();
    }

    public void AddDay() //goes to next day, sets timeOfDay to 1, adds to dayNumber and adds or resets monthCount
    {
        dayNumber += 1;
        if (monthToken == 0 && dayPerMonthCount >= 31) //we want it to check dayPerMonthCount before changing it.
        {
            dayPerMonthCount = 1;
            monthToken++;
        }
        else if (monthToken == 1 && dayPerMonthCount >= 29) //leap year in 2020
        {
            dayPerMonthCount = 1;
            monthToken++;
        }
        else if (monthToken == 2 && dayPerMonthCount >= 31)
        {
            dayPerMonthCount = 1;
            monthToken++;
        }
        else if(monthToken == 3 && dayPerMonthCount >= 30)
        {
            dayPerMonthCount = 1;
            monthToken++;
        }
        else if (monthToken == 4 && dayPerMonthCount >= 31)
        {
            dayPerMonthCount = 1;
            monthToken++;
        }
        else if (monthToken == 5 && dayPerMonthCount >= 30)
        {
            dayPerMonthCount = 1;
            monthToken++;
        }
        else if (monthToken == 6 && dayPerMonthCount >= 31)
        {
            dayPerMonthCount = 1;
            monthToken++;
        }
        else if (monthToken == 7 && dayPerMonthCount >= 31)
        {
            dayPerMonthCount = 1;
            monthToken++;
        }
        else if (monthToken == 8 && dayPerMonthCount >= 30)
        {
            dayPerMonthCount = 1;
            monthToken++;
        }
        else if (monthToken == 9 && dayPerMonthCount >= 31)
        {
            dayPerMonthCount = 1;
            monthToken++;
        }
        else if (monthToken == 10 && dayPerMonthCount >= 30)
        {
            dayPerMonthCount = 1;
            monthToken++;
        }
        else if (monthToken == 11 && dayPerMonthCount >= 31)
        {
            dayPerMonthCount = 1;
            monthToken = 0;
        }
        else
        {
            dayPerMonthCount++;
        }
        
        monthDisplay.text = "Month: " + monthName[monthToken];
        dayDisplay.text = "Day: " + dayPerMonthCount.ToString();
        timeOfDayDisplay.text = "Time of Day: " + timeOfDay.ToString();
    }
}
