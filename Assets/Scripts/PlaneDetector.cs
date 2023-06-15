using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Sabanishi
{
    /// <summary>
    /// 平面検知をし、タップされた場所を検知するクラス
    /// </summary>
    public class PlaneDetector:MonoBehaviour
    {
        private ARRaycastManager _arRaycastManager;

        private void Start()
        {
            _arRaycastManager = GetComponent<ARRaycastManager>();
        }

        private void Update()
        {
            var hits = new List<ARRaycastHit>();
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    if (_arRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                    {
                        Pose hiPose = hits[0].pose;
                        
                        //TODO:タップされた場所の情報を　　に送る
                    }
                }
            }
        }
    }
}