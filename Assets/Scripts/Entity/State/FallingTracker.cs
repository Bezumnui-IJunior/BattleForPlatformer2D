using System;
using Entity.IState;
using UnityEngine;

namespace Entity.State
{
    [Serializable]
    public class FallingTracker : Tracker, IFallingTracker
    {
        [SerializeField] private float _fallThreshold = 0.2f;

        private Rigidbody2D _rigidbody;

        private bool _isLastFall;

        public event Action StartFalling;
        public event Action StopFalling;
        
        public void Init(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public override void Update()
        {
            bool isFall = IsFall();

            if (_isLastFall == false && isFall)
                StartFalling?.Invoke();
            else if (_isLastFall && isFall == false)
                StopFalling?.Invoke();

            _isLastFall = isFall;
        }

        private bool IsFall() =>
            _rigidbody.linearVelocityY < -_fallThreshold;
    }
}