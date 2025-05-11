using System;
using System.Collections;
using Misc;

namespace Player.Trackers
{
    public class SuckTracker : ISuckTracker, IToggle
    {
        private readonly CooldownTimer _cooldownTimer;
        private readonly CooldownTimer _actionTimer;
        private readonly int _maxCount;
        private IEnumerator _enumerator;

        public SuckTracker(ICoroutineExecutor executor, int count, float cooldownSeconds, float actionSeconds)
        {
            _cooldownTimer = new CooldownTimer(executor, cooldownSeconds);
            _actionTimer = new CooldownTimer(executor, actionSeconds / count);
            _maxCount = count;
        }

        public bool CanSuck { get; private set; }
        public bool IsSuck { get; private set; }

        public event Action Sucking;
        public event Action SuckStopped;

        public void Enable()
        {
            CanSuck = true;
            _cooldownTimer.Freed += OnCooldownTimerFreed;
            _actionTimer.Freed += OnActionTimerFreed;
        }

        public void Disable()
        {
            _cooldownTimer.Freed -= OnCooldownTimerFreed;
            _actionTimer.Freed -= OnActionTimerFreed;
        }

        public void StartSuck()
        {
            if (CanSuck == false)
                return;

            CanSuck = false;
            IsSuck = false;
            _enumerator = SuckingEnumerator();
            _enumerator.MoveNext();
        }

        private IEnumerator SuckingEnumerator()
        {
            int lastCount = _maxCount;

            while (lastCount > 0)
            {
                Sucking?.Invoke();

                if (--lastCount > 0)
                {
                    _actionTimer.Start();

                    yield return null;
                }
            }

            SuckStopped?.Invoke();
            _cooldownTimer.Start();
        }

        private void OnActionTimerFreed()
        {
            IsSuck = false;
            _enumerator.MoveNext();
        }

        private void OnCooldownTimerFreed()
        {
            CanSuck = true;
        }
    }
}