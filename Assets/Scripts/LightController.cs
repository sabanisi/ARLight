using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Sabanishi
{
    /// <summary>
    /// LightObjectの生成、移動を行う
    /// </summary>
    public class LightController:MonoBehaviour
    {
        [SerializeField] private LightObjectPresenter _lightObjectPrefab;
        
        /// <summary>
        /// 選択中のLightObject
        /// </summary>
        private LightObjectPresenter _nowSelectedLightObject;
        
        /// <summary>
        /// 平面がタップされた時にその座標を受け取る
        /// </summary>
        public void OnTapPlane(Vector3 position)
        {
            Debug.Log(position);
            if (_nowSelectedLightObject == null) return;
            
            _nowSelectedLightObject.Model.SetNextPos(position);
        }
        
        /// <summary>
        /// LightObjectがタップされた時にそのオブジェクトを受け取る
        /// </summary>
        public void OnTapLightObject(LightObjectPresenter lightObject)
        {
            Debug.Log(lightObject);
            _nowSelectedLightObject = lightObject;
        }

        /// <summary>
        /// 生成ボタンが押された際の処理
        /// </summary>
        public void OnGenerateButtonClicked()
        {
            Debug.Log("Generate");
            _nowSelectedLightObject = Instantiate(_lightObjectPrefab);
            _nowSelectedLightObject.Initialize();
        }

        /// <summary>
        /// 移動ボタンが押された際の処理
        /// </summary>
        public void OnMoveButtonClicked()
        {
            Debug.Log("Move");
            if (_nowSelectedLightObject == null) return;
            _nowSelectedLightObject.Model.Move().Forget();
        }

        /// <summary>
        ///
        /// 点灯/消灯ボタンが押された際の処理
        /// </summary>
        public void OnTurnOnOffButtonClicked()
        {
            Debug.Log("TurnOnOff");
            if (_nowSelectedLightObject == null) return;
            _nowSelectedLightObject.Model.TurnOnOff();
        }
    }
}