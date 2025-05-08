using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using Misc;
using Physics;
using UnityEngine;

namespace Enemy
{
    [Serializable]
    public class EnemyDetector : IToggle
    {
        private bool _enabled;
        private WaitForSeconds _repeatDelay;
        private IDamageable _enemy;
        private NearbyDetector _nearbyDetector;
        private Coroutine _coroutine;
        private ICoroutineExecutor _executor;
        private List<IDamageable> _damaged = new(10);

        public EnemyDetector(ICoroutineExecutor executor, NearbyDetector nearbyDetector, float delaySeconds)
        {
            _executor = executor;
            _nearbyDetector = nearbyDetector;
            _repeatDelay = new WaitForSeconds(delaySeconds);
        }

        public event Action<IDamageable> EnemyDetected;

        public void Restart()
        {
            Disable();
            Enable();
        }

        public void Enable()
        {
            if (_enabled)
                return;

            _enabled = true;
            _coroutine = _executor.StartCoroutine(Detecting());
        }

        public void Disable()
        {
            if (_enabled == false)
                return;

            _enabled = false;
            _executor.StopCoroutine(_coroutine);
        }

        private IEnumerator Detecting()
        {
            while (_enabled)
            {
                _nearbyDetector.GetNearbyColliders(ref _damaged);

                foreach (IDamageable damageable in _damaged)
                {
                    EnemyDetected?.Invoke(damageable);
                }

                yield return _repeatDelay;
            }
        }
    }
}