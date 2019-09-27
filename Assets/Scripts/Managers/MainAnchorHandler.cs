using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

/// <Author>
/// Jonathan Aronsson Olsson
/// </Author>
/// <summary>
/// Create main anchor wich all the spawnobject will connect to
/// </summary>

public class MainAnchorHandler : MonoBehaviour
{
    public Anchor mainAnchor;
    public GameObject visualAnchor, visualAnchorClone;

    public void SpawnAnchor(TrackableHit anchorHit)
    {
        visualAnchorClone = Instantiate(visualAnchor, anchorHit.Pose.position, anchorHit.Pose.rotation);
        mainAnchor = anchorHit.Trackable.CreateAnchor(anchorHit.Pose);
    }
    //Child the gameobject to the anchor making it stable in the world
    public void SetAnchorAsParent(GameObject actor)
    {
        actor.transform.parent = mainAnchor.transform;
    }

    public void SetObjectAtAnchor(GameObject actor)
    {
        actor.transform.position = mainAnchor.transform.position;
    }
    public void DetachAnchor()
    {
        Destroy(visualAnchorClone);
        Destroy(mainAnchor);
    }
}
