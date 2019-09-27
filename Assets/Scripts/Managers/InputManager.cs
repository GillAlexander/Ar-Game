using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
/// <Author>
/// Jonathan Aronsson Olsson
/// Joakim Svensson
/// Michael Håkansson
/// </Author>
/// <summary>
/// A manager that controlls all the 
/// </summary>
public class InputManager : MonoBehaviour
{
    #region Managers 
    [HideInInspector]
    public GameWorld gameWorld;
    [HideInInspector]
    public RaycastManager rayManager;
    [HideInInspector]
    public TouchManager touchManager;
    [HideInInspector]
    public MainAnchorHandler anchorHandler;
    [HideInInspector]
    public ButtonStateMachine buttonStateMachine;
    [HideInInspector]
    public ObjectSpawnHandler objectSpawnHandler;
    [HideInInspector]
    public BAWS baws;
    #endregion

    TrackableHit hit;

    public void Start()
    {
        #region GetComponents
        gameWorld = GetComponent<GameWorld>();
        rayManager = GetComponent<RaycastManager>();
        touchManager = GetComponent<TouchManager>();
        anchorHandler = GetComponent<MainAnchorHandler>();
        buttonStateMachine = GetComponent<ButtonStateMachine>();
        objectSpawnHandler = GetComponent<ObjectSpawnHandler>();
        baws = gameObject.GetComponent<BAWS>();
        #endregion      
    }
}
