using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
/// <Author>
/// Michael Håkansson
/// Jonathan Aronsson Olsson
/// </Author>
/// <summary>
/// Statemachine for player actions
/// </summary>
public class StateMachineManager : MonoBehaviour
{
    public enum PlayerState { Idle, PlayerLook, PlayerMove, Play, Eating, PlayerPlay, PlayerDie, PlayerRessurect };

    #region Managers
    [HideInInspector]
    public Player player;
    [HideInInspector]
    public PlayerState playerState;
    [HideInInspector]
    public PlayerMove playerMove;
    [HideInInspector]
    public PlayerRotate playerRotate;
    [HideInInspector]
    public PlayerEat playerEat;
    [HideInInspector]
    public PlayerPlay playerPlay;
    [HideInInspector]
    public PlayerIdle playerIdle;
    [HideInInspector]
    public Tweens tweens;
    #endregion
    float time;
    float idleTimer;
    float anotherTimer;
    int randomInt;
    Rigidbody playerRb;
    ParticleSystem currentParticle;
    public void Start()
    {
        #region GetComponents
        player = GetComponent<Player>();
        playerMove = GetComponent<PlayerMove>();
        playerRotate = GetComponent<PlayerRotate>();
        playerEat = GetComponent<PlayerEat>();
        playerPlay = GetComponent<PlayerPlay>();
        playerIdle = GetComponent<PlayerIdle>();
        tweens = GetComponent<Tweens>();
        #endregion

        //player.spawnedPlayer.gameObject.transform.localScale = new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
    }

public void StateMachineManagerUpdate(GameObject spawnedFood, GameObject spawnedToy, GameObject anchor, float t)
    {
        t += Time.deltaTime;
        time += Time.deltaTime;
        idleTimer += Time.deltaTime;

        if (player.GetHappienessPoints() <= 0 || player.GetHungerPoints() <= 0)
        {
            playerState = PlayerState.PlayerDie;
        }

        switch (playerState)
        {
            case PlayerState.Idle:

                #region PlayerIDLE
                if (idleTimer > 4)
                {
                    randomInt = Random.Range(0, 2);
                    idleTimer = 0;
                }
                anotherTimer += Time.deltaTime;
                switch (randomInt)
                {
                    case 0:
                        playerRb = player.GetPlayerRb();
                        //Jumping
                        if (time > 1)
                        {
                        playerRb.AddForce(Vector3.up * 2.5f, ForceMode.Impulse);
                        time = 0;
                        }
                        break;
                    case 1:
                        //Nesting
                        playerRotate.RotateObjectTowardAnotherObject(player.spawnedPlayer, anchor);
                        playerMove.PlayerMoveTo(player.spawnedPlayer, player.startPos);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
                #endregion
                break;
                
            case PlayerState.PlayerLook:
                if (spawnedToy != null)
                {
                    if (t < 1)
                    {
                        playerRotate.RotateObjectTowardAnotherObject(player.spawnedPlayer, spawnedToy);
                    }
                    else if (t > 1)
                    {
                        playerState = PlayerState.PlayerMove;
                    }
                }
                if (spawnedFood != null)
                { 
                    if(t < 1)
                    playerRotate.RotateObjectTowardAnotherObject(player.spawnedPlayer, spawnedFood);
                    else if (t > 1)                   
                    {
                        playerState = PlayerState.PlayerMove;                       
                    }                
                }
                break;

            case PlayerState.PlayerMove:
                if (spawnedToy != null)
                {
                    playerMove.PlayerMoveTo(player.spawnedPlayer, spawnedToy.transform.position);
                    if (t > 3)
                    {
                        playerState = PlayerState.Play;
                    }
                }
                if (spawnedFood != null)
                {
                    playerMove.PlayerMoveTo(player.spawnedPlayer, spawnedFood.transform.position);
                    if (t > 3)
                    {                      
                        playerState = PlayerState.Eating;
                    }
                }
                break;

            case PlayerState.Play:

                if (t < 6)
                {
                    if (time > 1)
                    {
                        currentParticle  = Instantiate(tweens.toneParticle, player.spawnedPlayer.transform.position, player.spawnedPlayer.transform.rotation);
                        currentParticle.Play();
                        tweens.PlayerPeck(player.spawnedPlayer);
                        time = 0;
                    }
                }
                else if (t > 6)
                {
                    playerState = PlayerState.Idle;
                }
                break;

            case PlayerState.Eating:

                if (t < 6)
                {
                    if (time > 1)
                    {
                        tweens.PlayerPeck(player.spawnedPlayer);
                        time = 0;
                    }
                }
                else if (t > 6)
                {
                    currentParticle = Instantiate(tweens.loveParticle, player.spawnedPlayer.transform.position, player.spawnedPlayer.transform.rotation);
                    playerState = PlayerState.Idle;
                }

                break;

            case PlayerState.PlayerPlay:
                break;

            case PlayerState.PlayerDie:
                tweens.PlayerScaleExplode(player.spawnedPlayer);
                break;

            case PlayerState.PlayerRessurect:
                break;
            default:
                break;
        }
    }

}

