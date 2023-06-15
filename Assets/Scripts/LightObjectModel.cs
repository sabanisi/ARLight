using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace Sabanishi
{
    public class LightObjectModel
    {
        private const float MovingTime = 0.8f;
        
        /// <summary>
        /// 移動中かどうか
        /// </summary>
        private bool _isMoving;
        /// <summary>
        /// 次の目的地が決まっているか
        /// </summary>
        private bool _isNextMovePositionSet;
        /// <summary>
        /// 次の目的地
        /// </summary>
        private Vector3 _nextMovePos;
        
        private ReactiveProperty<Vector3> _pos;
        public IReadOnlyReactiveProperty<Vector3> Pos=>_pos;

        private ReactiveProperty<bool> _isOn;
        public IReadOnlyReactiveProperty<bool> IsOn => _isOn;

        public LightObjectModel()
        {
            _pos = new ReactiveProperty<Vector3>();
        }

        /// <summary>
        /// 次の目的地を設定する
        /// </summary>
        public void SetNextPos(Vector3 pos)
        {
            _isNextMovePositionSet = true;
            _nextMovePos = pos;
        }

        /// <summary>
        /// 次の目的地に移動する
        /// </summary>
        public async UniTask Move()
        {
            if (!_isNextMovePositionSet) return;
            if (_isMoving) return;
            
            //目的地に移動する
            _isMoving = true;
            DOTween.To(
                () => _pos.Value,
                pos => _pos.Value = pos,
                _nextMovePos,
                MovingTime
            ).OnComplete(() =>
            {
                _isNextMovePositionSet = false;
                _isMoving = false;
            });
        }
        
        /// <summary>
        /// 点灯/消灯を切り替える
        /// </summary>
        public void TurnOnOff()
        {
            _isOn.Value = !_isOn.Value;
        }
    }
}