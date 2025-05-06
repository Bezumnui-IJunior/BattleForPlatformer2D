using System.Collections;
using UnityEngine;

namespace Misc
{
    public class Cooldown
    {
        private readonly WaitForSeconds _delay;

        private Coroutine _coroutine;
        private readonly MonoBehaviour _monoBehaviour;
        
        public Cooldown(MonoBehaviour monoBehaviour, float delaySeconds)
        {
            _delay = new WaitForSeconds(delaySeconds);
            IsFree = true;
            _monoBehaviour = monoBehaviour;
        }

        public bool IsFree { get; private set; }

        public void Accuse()
        {
            _coroutine = _monoBehaviour.StartCoroutine(WaitingDelay());
        }

        public void Stop()
        {
            if (_coroutine != null)
                _monoBehaviour.StopCoroutine(_coroutine);
        }

        private IEnumerator WaitingDelay()
        {
            IsFree = false;

            yield return _delay;

            IsFree = true;
        }

    }
}