using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeTestController : MonoBehaviour
{
    public TextMeshProUGUI textTest;
    TimeSpan testDateTime;
    DateTime OrginalStartGameDate;
    Save save;
    void Start()
    {
        save = GetComponent<Save>();
        if(PlayerPrefs.GetInt("OrginalStartBool") != 1)
        {
            Debug.Log("Saved OrginalGameDate");
            save.OrginalGameDate();
        }
        OrginalStartGameDate = new DateTime(PlayerPrefs.GetInt("OrginalStartYear"), PlayerPrefs.GetInt("OrginalStartMonth"), PlayerPrefs.GetInt("OrginalStartDay"), PlayerPrefs.GetInt("OrginalStartHour"), PlayerPrefs.GetInt("OrginalStartMinute"), PlayerPrefs.GetInt("OrginalStartSecond"));
    }
    // Update is called once per frame
    void Update()
    {
        testDateTime = DateTime.Now - OrginalStartGameDate;
        textTest.text = "Days " + testDateTime.Days.ToString() + " Hours " + testDateTime.Hours.ToString() + " Minutes " + testDateTime.Minutes.ToString() + " Seconds " + testDateTime.Seconds.ToString();
    }

    public void ResetOrginalGameBool()
    {
        PlayerPrefs.SetInt("OrginalStartBool", 0);
        PlayerPrefs.DeleteAll();
    }
}
