using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static int dayNumber; //starts the week of August 26th, never resets, potentially unused until later.
    public static int weekNumber;
    
    public static int timeOfDay; //1 = before class, //1 = during class, //2 = after class, //3 = evening
    public static int dayPerMonthCount; //every time monthCount gets to maximum number of days in given month, the string associated with the month name changes and monthCount sets to 1
    public static string[] monthName = new string[13]; //name of the month displayed
    public LocationManager locationManager;
    private int monthToken; //goes in monthCount
    private string[] weekDayNames = new string[7];
    private int weekDayToken; //goes into weekdaynames
    private string[] dayTimeNames = new string[4];

    [SerializeField] private Text dateDisplay;
    [SerializeField] private Text weekDayDisplay;
    [SerializeField] private Text timeOfDayDisplay;
    
    
    void Awake() //these setters will be erased and probably put on the gameManager.
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
        
        weekDayNames[0] = "Monday";
        weekDayNames[1] = "Tuesday";
        weekDayNames[2] = "Wednesday";
        weekDayNames[3] = "Thursday";
        weekDayNames[4] = "Friday";
        weekDayNames[5] = "Saturday";
        weekDayNames[6] = "Sunday";

        dayTimeNames[0] = "Before Class";
        dayTimeNames[1] = "During Class";
        dayTimeNames[2] = "After Class";
        dayTimeNames[3] = "Evening";
        
        monthToken = 7; //starts in August
        weekDayToken = 0; //starts on a monday
        timeOfDay = 0; //starts in the morning
        dayNumber = 0;
        weekNumber = 0;
        
        dayPerMonthCount = 26; //starts on the 26th
        dateDisplay.text = monthName[monthToken] +" / "+ dayPerMonthCount.ToString();
        weekDayDisplay.text = "Day: " + weekDayNames[weekDayToken];
        timeOfDayDisplay.text = "Time of Day: " + dayTimeNames[timeOfDay];
    }
    

    public void AddTimeOfDay()
    {
        if (timeOfDay >= 3)
        {
            timeOfDay = 0;
            AddDay();
        }
        else
        {
            timeOfDay++;
        }

        timeOfDayDisplay.text = "Time of Day: " + dayTimeNames[timeOfDay];
        locationManager.AssignSpot(dayNumber, weekNumber, timeOfDay);
    }

    public void AddWeek()
    {
        for (int i = 0; i < 7; i++)
        {
            AddDay();
        }

    }
    public void AddDay() //goes to next day, sets timeOfDay to 1, adds to dayNumber and adds or resets monthCount
    {
        dayNumber += 1;
        
        if (weekDayToken >= 6)
        {
            weekDayToken = 0;
            weekNumber++;
        }
        else
        {
            weekDayToken++;
        }
        locationManager.AssignSpot(dayNumber, weekNumber, timeOfDay);
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
        
        dateDisplay.text = monthName[monthToken] +" / "+ dayPerMonthCount.ToString();
        weekDayDisplay.text = "Day: " + weekDayNames[weekDayToken];
    }
    
}
