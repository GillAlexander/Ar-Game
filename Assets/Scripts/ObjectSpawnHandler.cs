using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class ObjectSpawnHandler : MonoBehaviour
{
    public GameObject spawnedFood;
    public GameObject spawnedToy;
    public List<GameObject> toyPrefabs;
    public List<GameObject> toyList;
    public List<GameObject> foodPrefabs;
    public List<GameObject> foodList;
    [HideInInspector]
    public StateMachineManager stateMachineManager;
    [HideInInspector]
    public float foodTimer = 5, toyTimer = 5;
    public float t = 0;

    private void Start()
    {
        stateMachineManager = GetComponent<StateMachineManager>();
    }

    #region Food
    public void SpawnFood(TrackableHit hit) {
        int randomFood = Random.Range(0, foodPrefabs.Count);
        if (foodList.Count < 1)
        {
            //spawnedFood = Instantiate(foodPrefabs[randomFood], hit.Pose.position, hit.Pose.rotation);
            spawnedFood = Instantiate(foodPrefabs[randomFood], new Vector3(hit.Pose.position.x, stateMachineManager.player.spawnedPlayer.transform.position.y, hit.Pose.position.z), hit.Pose.rotation);
            //spawnedFood.transform.position = new Vector3(spawnedFood.transform.position.x, 0, spawnedFood.transform.position.z);
            foodList.Add(spawnedFood);
        }
    }

    public void UpdateDestroyFood()
    {
        t += Time.deltaTime;
        if (t > foodTimer)
        {
            Destroy(spawnedFood);
            foodList.Remove(spawnedFood);
            t = 0;
        }
    }
    
    
    public void UpdateDestroyToy()
    {
        t += Time.deltaTime;
        if (t > toyTimer)
        {
            Destroy(spawnedToy);
            toyList.Remove(spawnedToy);
            t = 0;
        }
    }
    #endregion
    #region Toy
    public void SpawnToy(TrackableHit hit)
    {

        int randomToy = Random.Range(0, toyPrefabs.Count);
        // change lookrotation
        if (toyList.Count < 1)
        {
            spawnedToy = Instantiate(toyPrefabs[randomToy], hit.Pose.position, hit.Pose.rotation);
            toyList.Add(spawnedToy);
        }
        

    }
    #endregion
    
}
