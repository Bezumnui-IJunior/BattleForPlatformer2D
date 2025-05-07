using Entity.Animators;
using Entity.Trackers;

namespace Entity
{
    public class EntityMotion
    {
        private readonly IMover _mover;
        private readonly IRotator _rotator;
        private readonly IMotionAnimator _motionAnimator;
        private readonly IStateTracker _tracker;

        public EntityMotion(IMover mover, IRotator rotator, IMotionAnimator motionAnimator, IStateTracker tracker)
        {
            _mover = mover;
            _rotator = rotator;
            _motionAnimator = motionAnimator;
            _tracker = tracker;
        }

        public void Jump() =>
            OnJumping();

        public void OnJumping()
        {
            if (_tracker.JumpingTracker.CanJump() == false)
                return;

            _tracker.JumpingTracker.Jump();
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
            _tracker.WalkingTracker.WalkingStopped += OnStoppingWalking;
            _tracker.JumpingTracker.JumpingStopped += OnStoppedJumping;
            _tracker.FallingTracker.FallingStarting += OnStartingFall;
            _tracker.FallingTracker.FallingStopped += OnStoppingFall;
        }

        public void OnDisable()
        {
            _tracker.WalkingTracker.WalkingStopped -= OnStoppingWalking;
            _tracker.JumpingTracker.JumpingStopped -= OnStoppedJumping;
            _tracker.FallingTracker.FallingStarting -= OnStartingFall;
            _tracker.FallingTracker.FallingStopped -= OnStoppingFall;
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

        private void OnStoppingWalking() =>
            _motionAnimator.StopWalking();

        private void OnStoppedJumping() =>
            _motionAnimator.StopJumping();

        private void OnStartingFall() =>
            _motionAnimator.StartFalling();

        private void OnStoppingFall() =>
            _motionAnimator.StopFalling();

        private void TryStartWalking()
        {
            if (_tracker.WalkingTracker.TryStartWalk())
                _motionAnimator.StartWalking();
        }
    }
}