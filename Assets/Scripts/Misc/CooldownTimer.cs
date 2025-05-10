using System;
using System.Collections;
using UnityEngine;

namespace Misc
{
    public class CooldownTimer
    {
        private readonly WaitForSeconds _delay;

        private Coroutine _coroutine;
        private readonly ICoroutineExecutor _user;
        public event Action Freed;

        public CooldownTimer(ICoroutineExecutor user, float delaySeconds)
        {
            _delay = new WaitForSeconds(delaySeconds);
            IsFree = true;
            _user = user;
        }

        public bool IsFree { get; private set; }

        public void Restart()
        {
            Stop();
            Start();
        }

        public void Start()
        {
            if (IsFree == false)
                return;

            _coroutine = _user.StartCoroutine(WaitingDelay());
        }

        public void Stop()
        {
            if (IsFree)
                return;

            IsFree = true;

            if (_coroutine != null)
                _user.StopCoroutine(_coroutine);
        }

        private IEnumerator WaitingDelay()
        {
            IsFree = false;

            yield return _delay;

            IsFree = true;
            Freed?.Invoke();
        }
    }
}