using System;
using System.Collections;
using Entity;
using Physics;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(NearbyDetector))]
    public class EnemyDetector : MonoBehaviour
    {
        [SerializeField] private float _repeatSeconds = 0.2f;
        [SerializeField] private Collider2D _ignoreCollider;

        private WaitForSeconds _repeatDelay;
        private IDamageable _enemy;
        private NearbyDetector _nearbyDetector;
        private Coroutine _coroutine;

        public event Action<IDamageable> EnemyDetected;

        private void Awake()
        {
            _repeatDelay = new WaitForSeconds(_repeatSeconds);
            _nearbyDetector = GetComponent<NearbyDetector>();
        }

        private void OnEnable()
        {
            _coroutine = StartCoroutine(InvokingDetector());
        }

        private void OnDisable()
        {
            StopCoroutine(_coroutine);
        }

        private IEnumerator InvokingDetector()
        {
            while (enabled)
            {
                _nearbyDetector.GetNearbyColliders(out Collider2D[] colliders);

                foreach (Collider2D detected in colliders)
                {
                    if (detected == _ignoreCollider)
                        continue;

                    if (detected.TryGetComponent(out IDamageable enemy))
                        EnemyDetected?.Invoke(enemy);
                }

                yield return _repeatDelay;
            }
        }
    }
}