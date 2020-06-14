using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Schedule))]
public class ScheduleEditor : Editor
{
    Vector2 scrollPos;
    Schedule s;
    Schedule.WeekInSchedule blankWeek = new Schedule.WeekInSchedule();

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();
        s = (Schedule)target;
        GUILayout.BeginScrollView(scrollPos);
        for( int i = 0; i < s.weeks.Count - 1; i++)
        {
            GUILayout.Label("Week " + (i + 1) + ":",EditorStyles.boldLabel);
            GUILayout.Space(10f);
            foreach(Schedule.DayInSchedule d in s.weeks[i].daysInSchedule)
            {
                GUILayout.Label(d.myDay.ToString(),EditorStyles.boldLabel);
              
                foreach(Schedule.TimeSlot t in d.timeSlots)
                {
                    GUILayout.BeginHorizontal();

                    t.myTime = (Year.Time)EditorGUILayout.EnumFlagsField(t.myTime);
                    t.myLocation = (LocationManager.location)EditorGUILayout.EnumFlagsField(t.myLocation);
                    t.myClass = (Schedule.Class)EditorGUILayout.EnumFlagsField(t.myClass);
                    t.isStoryTime = EditorGUILayout.Toggle(t.isStoryTime);
                    GUILayout.EndHorizontal();
                    GUILayout.Space(2f);
                }
                  GUILayout.Space(5f);
            }

            if(GUILayout.Button("Remove This Week"))
            {
                s.weeks.Remove(s.weeks[i]);
            }
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        }
        if(GUILayout.Button("Add A Week"))
        {
            s.weeks.Add(blankWeek);
        }
        GUILayout.EndScrollView();
        GUILayout.FlexibleSpace();
    }
}
