using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;


public class Player : MonoBehaviour
{   
    [SerializeField]
    public GameObject player;
    private Vector3 playerPosition;
    private Quaternion playerRotation;
    public GameObject spawnedPlayer;
    public static Player instance;
    [HideInInspector]
    public Vector3 startPos;
    Rigidbody playerRb;
    private int hungerPoints;
    private int happienessPoints;

    private void Awake()
    {
        instance = this;
        if(PlayerPrefs.GetInt("CheckIfGameIsSaved") == 1)
        {
            hungerPoints = PlayerPrefs.GetInt("Health");
            happienessPoints = PlayerPrefs.GetInt("Happieness");
        }
    }

    public void CreatPlayer(Vector3 anchorPosition, Quaternion anchorRotation)
    {
        if (spawnedPlayer == null)
        {
            playerPosition = anchorPosition;
            playerRotation = anchorRotation;
            spawnedPlayer = Instantiate(player, new Vector3(playerPosition.x, playerPosition.y + 0.05f, playerPosition.z), playerRotation);           
            startPos = playerPosition;
        }
        else Debug.Log("Player " + spawnedPlayer.transform.position.ToString());
    }

    public void SetPlayerPosition(Vector3 position)
    {
        playerPosition = position;
        spawnedPlayer.transform.position = playerPosition;
    }

    public void SetPlayerRotation(Quaternion rotation)
    {
        playerRotation = rotation;
        spawnedPlayer.transform.rotation = playerRotation;
    }

    public Vector3 GetPlayerTransform()
    {
        return playerPosition;
    }

    public Quaternion GetPlayerRotation()
    {
        return playerRotation;
    }

    public Rigidbody GetPlayerRb()
    {
        playerRb = spawnedPlayer.GetComponent<Rigidbody>();
        return playerRb;
    }
   
    public void PlayerGainHungerPoints(int i)
    {
        hungerPoints += i;
        hungerPoints = Mathf.Clamp(hungerPoints, 0, 100);
    }

    public void PlayerLossHungerPoints(int i)
    {
        hungerPoints += -i;
        hungerPoints = Mathf.Clamp(hungerPoints, 0, 100);
    }

    public void PlayerGainHappienessPoints(int i)
    {
        happienessPoints += i;
        happienessPoints = Mathf.Clamp(happienessPoints, 0, 100);
    }

    public void PlayerLossHappienessPoints(int i)
    {
        happienessPoints += -i;
        happienessPoints = Mathf.Clamp(happienessPoints, 0, 100);
    }

    public int GetHappienessPoints()
    {
        return happienessPoints;
    }

    public int GetHungerPoints()
    {
        return hungerPoints;
    }

    public void SetHungerAndHappienessPoints(int hunger, int happieness)
    {
        hungerPoints = hunger;
        happienessPoints = happieness;
    }
}