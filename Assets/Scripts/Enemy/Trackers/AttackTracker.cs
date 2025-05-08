using System;
using Misc;

namespace Enemy.Trackers
{
    public class AttackTracker : IAttackTracker
    {
        private readonly IAttackField _attackField;
        private readonly CooldownTimer _timer;

        public bool CanAttack { get; private set; } = true;

        public AttackTracker(ICoroutineExecutor executor, float cooldownSeconds, IAttackField attackField)
        {
            _attackField = attackField;

            _timer = new CooldownTimer(executor, cooldownSeconds);
        }

        public event Action AttackAllowed;

        public void Enable()
        {
            _timer.Freed += OnCooldownPass;
            _attackField.TargetEntered += OnTargetEntered;
        }

        public void Disable()
        {
            _timer.Freed -= OnCooldownPass;
            _attackField.TargetEntered -= OnTargetEntered;
        }

        public void Attack()
        {
            CanAttack = false;
            _timer.Start();
        }

        private void OnCooldownPass()
        {
            CanAttack = true;

            if (_attackField.IsContainTarget)
                AttackAllowed?.Invoke();
        }

        private void OnTargetEntered()
        {
            if (CanAttack == false)
                return;

            AttackAllowed?.Invoke();
        }
    }
}