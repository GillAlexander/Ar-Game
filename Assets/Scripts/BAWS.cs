using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAWS : MonoBehaviour
{
    float size = 0.3f;

    public void Resize(GameObject player, float percentage)
    {
        //  float size = player.transform.localScale.x;
        Debug.Log(percentage +"BO$$ number");
        player.transform.localScale = new Vector3((size * percentage / 100 * 2),size , size );
            
    }
}
