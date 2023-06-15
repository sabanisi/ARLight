using UnityEngine;

namespace Sabanishi
{
    /// <summary>
    /// 電球オブジェクト
    /// </summary>
    public class LightObjectPresenter:MonoBehaviour
    {
        [SerializeField] private LightObjectView _view;
        private LightObjectModel _model;

        public void Initialize()
        {
            _model = new LightObjectModel();
            
        }
    }
}