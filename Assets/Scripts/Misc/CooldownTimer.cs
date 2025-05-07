using System.Collections;
using UnityEngine;

namespace Misc
{
    public class CooldownTimer
    {
        private readonly WaitForSeconds _delay;

        private Coroutine _coroutine;
        private readonly ITimerUser _user;

        public CooldownTimer(ITimerUser user, float delaySeconds)
        {
            _delay = new WaitForSeconds(delaySeconds);
            IsFree = true;
            _user = user;
        }

        public bool IsFree { get; private set; }

        public void Occupy()
        {
            _coroutine = _user.StartCoroutine(WaitingDelay());
        }

        public void Stop()
        {
            if (_coroutine != null)
                _user.StopCoroutine(_coroutine);
        }

        private IEnumerator WaitingDelay()
        {
            IsFree = false;

            yield return _delay;

            IsFree = true;
        }
    }
}