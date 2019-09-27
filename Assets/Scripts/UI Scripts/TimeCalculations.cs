using System;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;

public class TimeCalculations : MonoBehaviour
{
    private DateTime now;
    private DateTime timeRules;
    public int lifeTimeDays;
    public int lifeTimeHours;
    public int lifeTimeMinutes;
    public TimeSpan tmpLifeTime;
    private readonly Double minutsToAdd = 14.00;
  
    void Start()
    {
        now = DateTime.Now;
    }

    public void TimeCalculationsUpdate()
    {
        now = DateTime.Now;
        LifeTime();
    }

    public void Eating()
    {
        AddTimeToTimeRules();
    }

    public void Playing()
    {
        AddTimeToTimeRules();
    }


    public DateTime GetNowTime()
    {
        return now;
    }

    public DateTime GetTimeRules()
    {
        return timeRules;
    }

    public void AddTimeToTimeRules()
    {
        timeRules = DateTime.Now.AddMinutes(minutsToAdd);
    }

    public void LifeTime()
    {
        tmpLifeTime = now - new DateTime(PlayerPrefs.GetInt("OrginalStartYear"), PlayerPrefs.GetInt("OrginalStartMonth"), PlayerPrefs.GetInt("OrginalStartDay"), PlayerPrefs.GetInt("OrginalStartHour"), PlayerPrefs.GetInt("OrginalStartMinute"), PlayerPrefs.GetInt("OrginalStartSecond"));
        if (tmpLifeTime.TotalDays >= 1) lifeTimeDays = (int)tmpLifeTime.TotalDays;
        else lifeTimeDays = 0;
        if (tmpLifeTime.TotalHours >= 1) lifeTimeHours = (int)tmpLifeTime.TotalHours;
        else lifeTimeHours = 0;
        if (tmpLifeTime.TotalMinutes >= 1) lifeTimeMinutes = (int)tmpLifeTime.TotalMinutes;
        else lifeTimeMinutes = 0;
    }
}
