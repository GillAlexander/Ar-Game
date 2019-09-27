using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
/// <Author>
/// Michael Håkansson
/// Jonathan Aronsson Olsson
/// </Author>
/// <summary>
/// Handle touch 
/// </summary>
public class TouchManager : MonoBehaviour
{
    public Touch screenTouch;
    private int touchIndex;


    public void UpdateTouch()
    {
        if (Input.touchCount < 1 && (screenTouch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }
        else if (Input.touchCount > 0 && (screenTouch = Input.GetTouch(0)).phase == TouchPhase.Began)
        {
            screenTouch = Input.GetTouch(0);
        }
    }

    public Touch GetTouch()
    {
        UpdateTouch();
        return screenTouch;
    }
    public int GetTouchIndex()
    {
        touchIndex = Input.GetTouch(0).fingerId;
        return touchIndex;
    }
    
}
