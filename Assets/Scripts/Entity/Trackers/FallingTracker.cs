using System;
using UnityEngine;

namespace Entity.Trackers
{
    public class FallingTracker : Tracker, IFallingTracker
    {
        private readonly float _fallThreshold;

        private readonly Rigidbody2D _rigidbody;

        private bool _isLastFall;
        
        public event Action FallingStarting;
        public event Action FallingStopped;
        
        public FallingTracker(Rigidbody2D rigidbody, float fallThreshold)
        {
            _rigidbody = rigidbody;
            _fallThreshold = fallThreshold;
        }

        public override void Update()
        {
            bool isFall = IsFall();

            if (_isLastFall == false && isFall)
                FallingStarting?.Invoke();
            else if (_isLastFall && isFall == false)
                FallingStopped?.Invoke();

            _isLastFall = isFall;
        }

        private bool IsFall() =>
            _rigidbody.linearVelocityY < -_fallThreshold;
    }
}