namespace GoogleARCore.Examples.HelloAR
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using Input = InstantPreviewInput;
using UnityEngine.EventSystems;
   
    public class Controller : MonoBehaviour
    {
        TrackableHit hit;
        public GameObject obj;
        public List<Anchor> anchors = new List<Anchor>();

        public void UpdateController()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            Touch touch;

            if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
            {
                return;
            }

            TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon | TrackableHitFlags.FeaturePointWithSurfaceNormal; 
            if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
            {
                if (hit.Trackable is FeaturePoint || hit.Trackable is DetectedPlane)
                {
                    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        Debug.Log("Touched position: " + hit.Pose.position);
                        var anchor = hit.Trackable.CreateAnchor(hit.Pose);
                        anchors.Add(anchor);
                        var currentAnchor = anchors[anchors.Count - 1];
                        Player.instance.SetPlayerPosition(currentAnchor.transform.position);
                        StartCoroutine("ClearAnchors");
                    }
                }
            }
        }

        public IEnumerator ClearAnchors()
        {
            yield return new WaitForSeconds(2);
            anchors.RemoveRange(0, anchors.Count - 1);
            ClearAnchors();
        }
    }
}