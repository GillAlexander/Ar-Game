using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class ResetGame : MonoBehaviour
{
    GameController gameController;
    void Start()
    {
        gameController = GetComponent<GameController>();
    }
    public void Reset(GameObject player, GameObject visualAnchor, Anchor anchor)
    {
        Destroy(player);
        Destroy(visualAnchor);
        Destroy(anchor);
        PlayerPrefs.DeleteAll();
        gameController.SetGameStart();
        Debug.Log("RESTART");

    }
}
