using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using Misc;
using UnityEngine;

namespace Enemy
{
    [Serializable]
    public class EnemyDetector : IToggle
    {
        private Coroutine _coroutine;
        private List<IDamageable> _damageables = new(10);
        private bool _enabled;
        private IDamageable _enemy;
        private ICoroutineExecutor _executor;
        private EnemyNearbyDetector _nearbyDetector;
        private WaitForSeconds _repeatDelay;

        public EnemyDetector(ICoroutineExecutor executor, EnemyNearbyDetector nearbyDetector, float delaySeconds)
        {
            _executor = executor;
            _nearbyDetector = nearbyDetector;
            _repeatDelay = new WaitForSeconds(delaySeconds);
        }

        public event Action<IDamageable> EnemyDetected;

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

        public void Restart()
        {
            Disable();
            Enable();
        }

        private IEnumerator Detecting()
        {
            while (_enabled)
            {
                _nearbyDetector.GetNearbyColliders(out IEnumerable<IDamageable> damageables);
                CopyIEnumerable(damageables);

                foreach (IDamageable damageable in _damageables) EnemyDetected?.Invoke(damageable);

                yield return _repeatDelay;
            }
        }

        private void CopyIEnumerable(IEnumerable<IDamageable> damageables)
        {
            _damageables.Clear();

            foreach (IDamageable damageable in damageables) _damageables.Add(damageable);
        }
    }
}