using UnityEngine;

namespace Sabanishi
{
    public class LightObjectView:MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private GameObject _onObj;
        [SerializeField] private GameObject _offObj;

        public void OnChangedPos(Vector3 pos)
        {
            _transform.position = pos;
        }

        public void OnChangedIsOn(bool isOn)
        {
            _onObj.SetActive(false);
            _offObj.SetActive(false);
            if (isOn)
            {
                _onObj.SetActive(true);
            }
            else
            {
                _offObj.SetActive(true);
            }
        }
    }
}