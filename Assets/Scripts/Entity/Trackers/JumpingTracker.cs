using System;
using Misc;

namespace Entity.Trackers
{
    public class JumpingTracker : Tracker, IJumpingTracker
    {
        private readonly IEntityTracker _entityTracker;
        private readonly CooldownTimer _jumpCooldownTimer;

        private bool _isJump;
        public event Action JumpingStopped;

        public JumpingTracker(EntityTracker entityTracker, float jumpCooldown)
        {
            _entityTracker = entityTracker;
            _jumpCooldownTimer = new CooldownTimer(entityTracker, jumpCooldown);
        }

        public bool CanJump()
        {
            return _entityTracker.Ground.IsGround && _isJump == false;
        }

        public void Jump()
        {
            _isJump = true;

            _jumpCooldownTimer.Stop();
            _jumpCooldownTimer.Start();
        }

        public override void Update()
        {
            if (_isJump == false)
                return;

            if (_jumpCooldownTimer.IsFree == false)
                return;

            if (_entityTracker.Ground.IsGround == false)
                return;

            _isJump = false;
            JumpingStopped?.Invoke();
        }
    }
}