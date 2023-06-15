using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Sabanishi
{
    public class ARTest:MonoBehaviour
    {
        [SerializeField] private GameObject _spawnedObject;

        private ARRaycastManager _arRaycastManager;
        private List<ARRaycastHit> hits = new List<ARRaycastHit>();

        private void Start()
        {
            _arRaycastManager = GetComponent<ARRaycastManager>();
        }

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    if (_arRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                    {
                        Pose hiPose = hits[0].pose;
                        Instantiate(_spawnedObject, hiPose.position, hiPose.rotation);
                    }
                }
            }
        }
    }
}