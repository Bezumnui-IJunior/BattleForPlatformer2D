using Entity.IState;
using Move;
using UnityEngine;


namespace Entity
{
    [RequireComponent(typeof(IMover))]
    [RequireComponent(typeof(IInput))]
    [RequireComponent(typeof(IEntityAnimator))]
    [RequireComponent(typeof(IStateTracker))]
    public class Entity : MonoBehaviour
    {
        private IMover _move;
        private IInput _input;
        private IRotator _rotator;
        private IEntityAnimator _animator;
        private IStateTracker _tracker;

        private void Awake()
        {
            _move = GetComponent<IMover>();
            _input = GetComponent<IInput>();
            _animator = GetComponent<IEntityAnimator>();
            _tracker = GetComponent<IStateTracker>();
            _rotator = GetComponent<IRotator>();

            _tracker.Initialize();
        }

        private void OnEnable()
        {
            _input.GoingLeft += OnGoingLeft;
            _input.GoingRight += OnGoingRight;
            _input.HorizontalStopping += OnWalkingStopping;
            _input.Jumping += OnJumping;
            _tracker.WalkingTracker.WalkingStoped += OnWalkingStopping;
            _tracker.JumpingTracker.JumpingStopped += OnJumpStopped;
            _tracker.FallingTracker.FallingStarting += OnFallingStarted;
            _tracker.FallingTracker.FallingStopped += OnFallingStopped;
        }

        private void OnDisable()
        {
            _input.GoingLeft -= OnGoingLeft;
            _input.GoingRight -= OnGoingRight;
            _input.HorizontalStopping -= OnWalkingStopping;
            _input.Jumping -= OnJumping;
            _tracker.WalkingTracker.WalkingStoped -= OnWalkingStopping;
            _tracker.JumpingTracker.JumpingStopped -= OnJumpStopped;
            _tracker.FallingTracker.FallingStarting -= OnFallingStarted;
            _tracker.FallingTracker.FallingStopped -= OnFallingStopped;
        }

        private void OnGoingLeft()
        {
            _move.GoLeft();
            _rotator.LookLeft();
            TryStartWalking();
        }

        private void OnGoingRight()
        {
            _move.GoRight();
            _rotator.LookRight();
            TryStartWalking();
        }

        private void TryStartWalking()
        {
            if (_tracker.WalkingTracker.TryStartWalk())
                _animator.StartWalking();
        }

        private void OnWalkingStopping()
        {
            _move.Stay();
            _animator.StopWalking();
        }

        private void OnJumping()
        {
            if (_tracker.JumpingTracker.CanJump() == false)
                return;

            _tracker.JumpingTracker.Jump();
            _move.Jump();
            _animator.StartJumping();
        }

        private void OnJumpStopped()
        {
            _animator.StopJumping();
        }

        private void OnFallingStarted()
        {
            _animator.StartFalling();
        }

        private void OnFallingStopped()
        {
            _animator.StopFalling();
        }
    }
}