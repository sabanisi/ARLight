using UnityEngine;

namespace Sabanishi
{
    public class LightObjectView:MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private GameObject _onObj;
        [SerializeField] private GameObject _offObj;
        [SerializeField] private Transform _verTra;

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

        private void Update()
        {
            //カメラの方を向く
            Vector3 rot = Camera.main.transform.position - _transform.position;
            Vector3 verVec = _verTra.position - _transform.position;
            rot -= Vector3.Dot(rot, verVec) * verVec;
            _transform.rotation = Quaternion.Euler(rot.x,rot.y,rot.z);
        }
    }
}