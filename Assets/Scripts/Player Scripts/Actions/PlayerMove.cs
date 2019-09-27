using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    float t;

private void Start()
    {
        t = Time.deltaTime;
    }
    public void PlayerMoveTo(  GameObject player, Vector3 food  )
    {        //Debug.Log($"Vector 3 :{player}");
        //player.transform.Translate(Vector3.forward * Time.deltaTime);

        player.transform.position = Vector3.Lerp(player.transform.position, food, t);
    }
}
