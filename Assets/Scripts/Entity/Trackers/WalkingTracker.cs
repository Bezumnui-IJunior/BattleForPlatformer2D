using System;
using UnityEngine;

namespace Entity.Trackers
{
    public class WalkingTracker : Tracker, IWalkingTracker
    {
        private bool _isWalk;
        private readonly Rigidbody2D _rigidbody;

        public WalkingTracker(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public event Action WalkingStopped;

        public override void Update()
        {
            bool isWalk = _rigidbody.linearVelocityX == 0;

            if (_isWalk && isWalk)
                WalkingStopped?.Invoke();

            _isWalk = isWalk;
        }

        public bool TryStartWalk()
        {
            if (_isWalk)
                return false;

            _isWalk = true;

            return true;
        }
    }
}