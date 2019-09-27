using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

/// <Author>
/// Michael Håkansson
/// Jonathan Aronsson Olsson
/// </Author>
/// <summary>
/// Manage raycasts
/// </summary>
public class RaycastManager : MonoBehaviour
{
    private TrackableHit hit;
    public RaycastHit rayHit;
    private Vector3 hitArea;


    public void UpdateRaycastManager()
    {

    }
    //Raycast from the touch of the screen to the real world, searching for trackables 
    public TrackableHit UpdateWorldRayCast(Touch touch)
    {
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon | TrackableHitFlags.FeaturePointWithSurfaceNormal;
        if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {
            if (hit.Trackable is FeaturePoint || hit.Trackable is DetectedPlane)
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    //Debug.Log("Touched position: " + hit.Pose.position);
                }
            }
        }

        return hit;
    }

    public RaycastHit UpdateUnityRayCast(Touch touch)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

        if (Physics.Raycast(ray, out rayHit))
        {


            return rayHit;
        }
        return rayHit;


    }
}
