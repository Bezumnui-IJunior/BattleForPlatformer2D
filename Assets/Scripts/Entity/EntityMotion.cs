using Entity.Animators;
using Entity.Trackers;

namespace Entity
{
    public class EntityMotion
    {
        private readonly IMotionAnimator _motionAnimator;
        private readonly IMover _mover;
        private readonly IRotator _rotator;
        private readonly IEntityTracker _tracker;

        public EntityMotion(IMover mover, IRotator rotator, IMotionAnimator motionAnimator, IEntityTracker tracker)
        {
            _mover = mover;
            _rotator = rotator;
            _motionAnimator = motionAnimator;
            _tracker = tracker;
        }

        public void Jump()
        {
            OnJumping();
        }

        public void OnJumping()
        {
            if (_tracker.Jump.CanJump() == false)
                return;

            _tracker.Jump.Jump();
            _mover.Jump();
            _motionAnimator.StartJumping();
        }

        public void GoWithSpeed(float speed)
        {
            _mover.SetSpeedByX(speed);

            if (speed > 0)
                GoRight();
            else if (speed < 0)
                GoLeft();
        }

        public void OnEnable()
        {
            _tracker.Walk.WalkingStopped += OnStoppingWalking;
            _tracker.Jump.JumpingStopped += OnStoppedJump;
            _tracker.Fall.FallingStarting += OnStartingFall;
            _tracker.Fall.FallingStopped += OnStoppingFall;
        }

        public void OnDisable()
        {
            _tracker.Walk.WalkingStopped -= OnStoppingWalking;
            _tracker.Jump.JumpingStopped -= OnStoppedJump;
            _tracker.Fall.FallingStarting -= OnStartingFall;
            _tracker.Fall.FallingStopped -= OnStoppingFall;
        }

        private void GoRight()
        {
            _rotator.LookRight();
            TryStartWalking();
        }

        private void GoLeft()
        {
            _rotator.LookLeft();
            TryStartWalking();
        }

        private void OnStoppingWalking()
        {
            _motionAnimator.StopWalking();
        }

        private void OnStoppedJump()
        {
            _motionAnimator.StopJumping();
        }

        private void OnStartingFall()
        {
            _motionAnimator.StartFalling();
        }

        private void OnStoppingFall()
        {
            _motionAnimator.StopFalling();
        }

        private void TryStartWalking()
        {
            if (_tracker.Walk.TryStartWalk())
                _motionAnimator.StartWalking();
        }
    }
}