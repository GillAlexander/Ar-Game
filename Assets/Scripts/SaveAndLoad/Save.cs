using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("OrginalStartBool") != 1) OrginalGameDate();
    }
    public void SaveGameState(int hunger, int happieness, DateTime dateTime)
    {
        PlayerPrefs.SetInt(("Year"), dateTime.Year);
        PlayerPrefs.SetInt(("Month"), dateTime.Month);
        PlayerPrefs.SetInt(("Day"), dateTime.Day);
        PlayerPrefs.SetInt(("Hour"), dateTime.Hour);
        PlayerPrefs.SetInt(("Minute"), dateTime.Minute);
        PlayerPrefs.SetInt(("Second"), dateTime.Second);
        PlayerPrefs.SetInt(("Health"), hunger);
        PlayerPrefs.SetInt(("Happieness"), happieness);
        PlayerPrefs.SetInt(("CheckIfGameIsSaved"), 1);
    }

    public void OrginalGameDate()
    {
        PlayerPrefs.SetInt("OrginalStartYear", DateTime.Now.Year);
        PlayerPrefs.SetInt("OrginalStartMonth", DateTime.Now.Month);
        PlayerPrefs.SetInt("OrginalStartDay", DateTime.Now.Day);
        PlayerPrefs.SetInt("OrginalStartHour", DateTime.Now.Hour);
        PlayerPrefs.SetInt("OrginalStartMinute", DateTime.Now.Minute);
        PlayerPrefs.SetInt("OrginalStartSecond", DateTime.Now.Second);
        PlayerPrefs.SetInt("OrginalStartBool", 1);
    }
}
