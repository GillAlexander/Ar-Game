using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour {

    public void RotateObjectTowardAnotherObject(GameObject player, GameObject food) {

        int damping = 4;
        var lookPos = food.transform.position - player.transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, rotation, Time.deltaTime * damping);


    }
}
