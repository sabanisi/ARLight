using System;
using UnityEngine;

namespace Sabanishi
{
    /// <summary>
    /// タップの検出を統括管理する
    /// </summary>
    public class InputManager:MonoBehaviour
    {
        [SerializeField] private LightController _lightController;
        private PlaneDetector _planeDetector;
        private LightObjectDetector _lightObjectDetector;

        private void Start()
        {
            _planeDetector = GetComponent<PlaneDetector>();
            _lightObjectDetector = GetComponent<LightObjectDetector>();
        }

        private void Update()
        {
            //タップされた場所にLightObjectがあるかどうかを検知する
            var lightDetectResult = _lightObjectDetector.Detect();
            if (lightDetectResult.Item1)
            {
                _lightController.OnTapLightObject(lightDetectResult.Item2);
                return;
            }
            
            //タップされた場所に平面があるかどうかを検知する
            var planeDetectResult = _planeDetector.Detect();
            if (planeDetectResult.Item1)
            {
                _lightController.OnTapPlane(planeDetectResult.Item2);
            }
        }
    }
}