using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Sabanishi
{
    /// <summary>
    /// 平面検知をし、タップされた場所を検知するクラス
    /// </summary>
    public class PlaneDetector : MonoBehaviour
    {
        private ARRaycastManager _arRaycastManager;

        private void Start()
        {
            _arRaycastManager = GetComponent<ARRaycastManager>();
        }


        /// <summary>
        /// タップされた場所に平面があるかどうかを検知する
        /// </summary>
        /// <returns>(平面があるか、平面の座標)</returns>
        public (bool, Vector3) Detect()
        {
            var hits = new List<ARRaycastHit>();
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    //UIへのボタンタップがある場合、以降の処理を行わない
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                        {
                            return (false, Vector3.zero);
                        }
                    }

                    if (_arRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                    {
                        Pose hitPose = hits[0].pose;

                        //タップされた場所の情報をLightControllerに送る
                        return (true, hitPose.position);
                    }
                }
            }
            return (false, Vector3.zero);
        }
    }
}