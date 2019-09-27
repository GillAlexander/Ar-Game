using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Author>
/// Jonathan Aronsson Olsson
/// </Author>
/// <summary>
/// Make sure there can only be one anchor
/// </summary>
public class AnchorSingelton : MonoBehaviour
{

    public static AnchorSingelton instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
}