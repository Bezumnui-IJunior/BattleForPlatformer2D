using System;
using Entity.IState;
using Move;
using UnityEngine;

namespace Entity.State
{
    [Serializable]
    public class JumpingTracker : Tracker, IJumpingTracker
    {
        private bool _isJump;
        private float _jumpTime;

        private IStateTracker _stateTracker;
        private IMove _move;

        public event Action StartJumping;
        public event Action StopJumping;

        public void Init(IStateTracker stateTracker, IMove move)
        {
            _move = move;
            _stateTracker = stateTracker;
        }

        public override void Update()
        {
        }

        public override void OnEnable()
        {
            _move.StartJumping += OnStartJumping;
            _stateTracker.GroundedTracker.Grounded += OnGrounded;
        }

        public override void OnDisable()
        {
            _move.StartJumping -= OnStartJumping;
            _stateTracker.GroundedTracker.Grounded -= OnGrounded;
        }

        private void OnGrounded()
        {
            if (_isJump == false)
                return;

            _isJump = false;
            StopJumping?.Invoke();
        }

        private void OnStartJumping()
        {
            _isJump = true;
            _jumpTime = Time.realtimeSinceStartup;
            StartJumping?.Invoke();
        }
    }
}