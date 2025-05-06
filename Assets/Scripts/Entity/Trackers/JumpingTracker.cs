using System;
using Entity.IState;
using Misc;
using UnityEngine;

namespace Entity.Trackers
{
    public class JumpingTracker : Tracker, IJumpingTracker
    {
        private readonly IStateTracker _stateTracker;
        private readonly CooldownTimer _jumpCooldownTimer;

        private bool _isJump;
        public event Action JumpingStopped;

        public JumpingTracker(StateTracker stateTracker, float jumpCooldown)
        {
            _stateTracker = stateTracker;
            _jumpCooldownTimer = new CooldownTimer(stateTracker, jumpCooldown);
        }

        public bool CanJump()
        {
            return _stateTracker.GroundedTracker.IsGround && _isJump == false;
        }

        public void Jump()
        {
            _isJump = true;

            _jumpCooldownTimer.Stop();
            _jumpCooldownTimer.Accuse();
        }

        public override void Update()
        {
            if (_isJump == false)
                return;

            if (_jumpCooldownTimer.IsFree == false)
                return;

            if (_stateTracker.GroundedTracker.IsGround == false)
                return;

            _isJump = false;
            JumpingStopped?.Invoke();
        }
    }
}