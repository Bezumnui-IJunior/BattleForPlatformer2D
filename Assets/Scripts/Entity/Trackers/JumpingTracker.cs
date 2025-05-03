using System;
using Entity.IState;
using Misc;
using UnityEngine;

namespace Entity.Trackers
{
    public class JumpingTracker : Tracker, IJumpingTracker
    {
        private readonly IStateTracker _stateTracker;
        private readonly Cooldown _jumpCooldown;

        private bool _isJump;
        public event Action JumpingStopped;

        public JumpingTracker(StateTracker stateTracker, float jumpCooldown)
        {
            _stateTracker = stateTracker;
            _jumpCooldown = new Cooldown(stateTracker, jumpCooldown);
        }

        public bool CanJump()
        {
            return _stateTracker.GroundedTracker.IsGround && _isJump == false;
        }

        public void Jump()
        {
            _isJump = true;

            _jumpCooldown.Stop();
            _jumpCooldown.Accuse();
        }

        public override void Update()
        {
            if (_isJump == false)
                return;

            if (_jumpCooldown.IsFree == false)
                return;

            if (_stateTracker.GroundedTracker.IsGround == false)
                return;

            _isJump = false;
            JumpingStopped?.Invoke();
        }
    }
}