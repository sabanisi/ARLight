using UniRx;
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
        public LightObjectModel Model => _model;

        public void Initialize()
        {
            _model = new LightObjectModel();
            _model.Pos.Subscribe(_view.OnChangedPos).AddTo(gameObject);
            _model.IsOn.Subscribe(_view.OnChangedIsOn).AddTo(gameObject);
        }
    }
}