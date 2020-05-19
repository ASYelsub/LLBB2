using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Year
{
    public Month[] months;

    public class Time
    {

    }

    public class Day
    {
        public Time[] timeOfDay;
    }

    public class Week
    {
        public Day[] days;   
    }

    public class Month
    {
        public Week[] weeks;
        public string _name;

        public Month(string s)
        {
            s = _name;
        }
    }
   
}
