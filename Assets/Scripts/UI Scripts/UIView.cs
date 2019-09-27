using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIView : UIController
{
    public TextMeshProUGUI lifeTime;
    public GameObject happyBarMeter;
    public GameObject hungerBarMeter;
    private int height = 30;
    private int happyWidth;
    private int hungerWidth;

    // FunPointsChange should be number from checkrules. but does not work yet
    public void SetHappyBarSize(int FunPointsChange)
    {
        happyWidth = FunPointsChange * 2;
        var happyBarMeterRectTransform = happyBarMeter.transform as RectTransform;
        happyBarMeterRectTransform.sizeDelta = new Vector2(happyWidth, height);
    }

    // HungerPointsChange should be number from checkrules. but does not work yet
    public void SetHungerBarMeter(int HungerPointsChange)
    {
        hungerWidth = HungerPointsChange * 2;
        var hungerBarMeterRectTransform = hungerBarMeter.transform as RectTransform;
        hungerBarMeterRectTransform.sizeDelta = new Vector2(hungerWidth, height);
    }
}
