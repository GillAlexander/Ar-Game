using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Created by Joakim
/// Edited by Ulrik
/// Edited by Patrik
/// </summary>

public class UIController : MonoBehaviour
{
    //protected Eat eat;
    //protected Entertainment entertainment;
    [HideInInspector]
    public UIView uiView;
    [HideInInspector]
    public UIMath uiMath;
    
    //  TODO: when working rename to UIUpdate() and link in GameController 
    public void UIControllerUpdate()
    {
        SetBars();
    }

    //Numbers below shoud come from GameController
    void Start()
    {
        uiView = GetComponent<UIView>();
        uiMath = GetComponent<UIMath>();
    }

    private void SetBars()
    {
        uiView.SetHungerBarMeter(uiMath.GetEating());
        uiView.SetHappyBarSize(uiMath.GetPlaying());
    }
}
