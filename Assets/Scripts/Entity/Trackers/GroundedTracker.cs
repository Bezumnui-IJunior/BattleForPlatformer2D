using System;
using Physics;

namespace Entity.Trackers
{
    public class GroundedTracker : Tracker, IGroundedTracker
    {
        private readonly IGroundChecker _groundChecker;

        public GroundedTracker(IGroundChecker groundChecker)
        {
            _groundChecker = groundChecker;
            IsGround = _groundChecker.IsGrounded();
        }

        public event Action Grounded;
        public bool IsGround { get; private set; }

        public override void Update()
        {
            if (_groundChecker.IsGrounded())
            {
                if (IsGround == false) 
                    Grounded?.Invoke();

                IsGround = true;

                return;
            }

            IsGround = false;
        }
    }
}