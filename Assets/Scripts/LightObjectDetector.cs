using System.Linq;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace Sabanishi
{
    /// <summary>
    /// LightObjectのタップを検知する
    /// </summary>
    public class LightObjectDetector:MonoBehaviour
    {
        [SerializeField] private Camera _arCamera;
        [SerializeField] private LayerMask _lightObjectLayer;
        
        /// <summary>
        /// タップされた場所にLightObjectがあるか
        /// </summary>
        /// <returns>(LightObjectがあるか、タップされたオブジェクト)</returns>
        public (bool,LightObjectPresenter) Detect()
        {
            if (Input.GetMouseButtonDown(0))
            {
                //UIへのボタンタップがある場合、以降の処理を行わない
                if (Input.GetMouseButtonDown(0))
                {
                    if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                    {
                        return (false,null);
                    }
                }
                
                var ray = _arCamera.ScreenPointToRay(Input.mousePosition);
                var raycastHits = Physics.RaycastAll(ray, Mathf.Infinity, _lightObjectLayer).ToList();
                if (raycastHits.Any())
                {
                    //タップされた位置にあるオブジェクトを取得
                    var lightObj = raycastHits.First().collider.gameObject.GetComponent<LightObjectPresenter>();
                    return (true, lightObj);
                }
            }
            return (false, null);
        }
    }
}