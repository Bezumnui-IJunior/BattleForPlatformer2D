using Entity.IState;

namespace Entity
{
    public class EntityMotion
    {
        private readonly IMover _mover;
        private readonly IRotator _rotator;
        private readonly IEntityAnimator _animator;
        private readonly IStateTracker _tracker;

        public EntityMotion(IMover mover, IRotator rotator, IEntityAnimator animator, IStateTracker tracker)
        {
            _mover = mover;
            _rotator = rotator;
            _animator = animator;
            _tracker = tracker;
        }

        public void OnJumping()
        {
            if (_tracker.JumpingTracker.CanJump() == false)
                return;

            _tracker.JumpingTracker.Jump();
            _mover.Jump();
            _animator.StartJumping();
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
            _animator.StopWalking();

        private void OnStoppedJumping() =>
            _animator.StopJumping();

        private void OnStartingFall() =>
            _animator.StartFalling();

        private void OnStoppingFall() =>
            _animator.StopFalling();

        private void TryStartWalking()
        {
            if (_tracker.WalkingTracker.TryStartWalk())
                _animator.StartWalking();
        }
    }
}