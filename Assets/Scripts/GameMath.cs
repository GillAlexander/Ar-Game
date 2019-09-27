using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameMath : MonoBehaviour
{
    int tmpYear;
    int tmpMonth;
    int tmpDay;
    int tmpHour;
    int tmpMinute;
    int calculateDayToHours;
    public int timeValue;
    int returnHappienessAndHungerLoss;

    public void GetingGameState()
    {
        tmpYear = DateTime.Now.Year - PlayerPrefs.GetInt("Year");
        tmpMonth = DateTime.Now.Month - PlayerPrefs.GetInt("Month");
        tmpDay = DateTime.Now.Day - PlayerPrefs.GetInt("Day");
        tmpHour = DateTime.Now.Hour - PlayerPrefs.GetInt("Hour");
        tmpMinute = DateTime.Now.Minute - PlayerPrefs.GetInt("Minute");

    }

    public void CalculateLoadGameState()
    {
        if (tmpYear > 0 || tmpMonth > 0) timeValue = 14000;
        if (tmpDay > 1) timeValue = 14000;
        if (tmpDay == 1)
        {
            calculateDayToHours = (tmpDay * 24) - PlayerPrefs.GetInt("Hour");
            if (tmpHour >= 0) timeValue = 14000;
            else
            {
                calculateDayToHours = DateTime.Now.Hour + calculateDayToHours;
                timeValue = calculateDayToHours * 60 + tmpMinute;
            }
        }
        if (tmpHour > 0) timeValue = tmpHour * 60 + tmpMinute;
    }

    public int CalculateHappienessAndHungerLoss()
    {
        for (int i = 0; i < timeValue; i++)
        {
            if (i % 14 == 1) returnHappienessAndHungerLoss++;
        }
        timeValue = 0;
        return returnHappienessAndHungerLoss;
    }
}
