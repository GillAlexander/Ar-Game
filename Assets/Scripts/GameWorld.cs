using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using GoogleARCore.Examples.Common;
using TMPro;
using System;
using UnityEngine.UI;

/// <author>
/// Jonathan Aronsson Olsson
/// Majorly edited by
/// Michael Håkansson
/// ARCore DetectedPlaneGenerator Template
/// </author>
/// <summary>
/// Visualize planes and save them in a list.
/// </summary>
public class GameWorld : MonoBehaviour
{
    public List<GameObject> currentPlanes = new List<GameObject>();
    public GameObject planePrefab;
    public List<DetectedPlane> planeList = new List<DetectedPlane>();
    public bool toggle;
    private Image toggleGenerateWorldButton;
	private GameObject tutorialText;


    public void Start()
    {
        toggleGenerateWorldButton = GameObject.Find("ToggleGenerateWorldButton").GetComponent<Button>().GetComponent<Image>();
        toggleGenerateWorldButton.color = Color.green;
		tutorialText = GameObject.Find("TutorialText");	
		tutorialText.SetActive(true);
    }

    public void Update()
    {
        FindPlaceToSpawnPlayer();
    }
    
    private void FindPlaceToSpawnPlayer()
    {
		Session.GetTrackables<DetectedPlane>(planeList, TrackableQueryFilter.New);
        for (int i = 0; i < planeList.Count; i++)
        {
            GameObject newPlane = Instantiate(planePrefab, Vector3.zero, Quaternion.identity);
            newPlane.GetComponent<DetectedPlaneVisualizer>().Initialize(planeList[i]);
        }
     
        GameObject[] planes = GameObject.FindGameObjectsWithTag("Plane");
        for (int i = 0; i < planes.Length; i++)
        {
            planes[i].GetComponent<DetectedPlaneVisualizer>().enabled = toggle;
        }
    }

  //  public void ToggleTracking()
  //  {
		//tutorialText.SetActive(false);
		//toggle = !toggle;
  //      ChangeColor();

  //  }

  //  public void DestroyWorld()
  //  {
  //      GameObject[] planes = GameObject.FindGameObjectsWithTag("Plane");
  //      for (int i = 0; i < planes.Length; i++)
  //      {
  //          Destroy(planes[i].gameObject);
  //      }
  //  }

    //public void ChangeColor()
    //{
    //    switch(toggle)
    //    {
    //        case true:
    //            Debug.Log("World Generation Enabled");
    //            toggleGenerateWorldButton.color = Color.red;
    //            break;
    //        case false:
    //            Debug.Log("World Generation Disabled");
    //            toggleGenerateWorldButton.color = Color.green;
    //            break;
    //        default:
    //            break;
    //    }
    //}
}