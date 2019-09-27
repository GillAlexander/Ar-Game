using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSingelton : MonoBehaviour
{
    public static FoodSingelton instance;

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
