using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public LocationManager locationManager;


    [SerializeField] private Text dateDisplay;
    [SerializeField] private Text weekDayDisplay;
    [SerializeField] private Text timeOfDayDisplay;
    
    
    void Awake() //these setters will be erased and probably put on the gameManager.
    {
        Year.currentMonth = (Year.WhichMonth)8; //starts in August
        Year.currentDay = 0; //starts on a monday
        Year.currentTime = 0; //starts in the morning
        Year.dayInMonth = 30;
        Year.currentWeek = 5;
        UpdateText();
      
    }
    
    public void UpdateText()
    {
        dateDisplay.text = Year.GetShortDate(); // displays something like this "January / 25"
        weekDayDisplay.text = "Day: " + Year.currentDay.ToString();
        timeOfDayDisplay.text = "Time of Day: " + Year.currentTime.ToString(); ;
    }

    public void AddTimeOfDay()
    {
        if (Year.currentTime == Year.Time.Evening)
        {
            Year.GoToNextDay();
        }
        else
        {
            Year.currentTime++;
        }

        locationManager.CharactersMove();
        UpdateText();
    }

    public void AddWeek()
    {
        Year.XDaysLater(7);
        UpdateText();
    }

    public void AddDay()
    {
        Year.GoToNextDay();
        UpdateText();
    }
   
    
}
