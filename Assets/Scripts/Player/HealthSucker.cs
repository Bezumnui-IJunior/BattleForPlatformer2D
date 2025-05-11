using System.Collections.Generic;
using Entity;
using Player.Trackers;
using UnityEngine;

namespace Player
{
    public class HealthSucker : MonoBehaviour, ICoroutineExecutor
    {
        [SerializeField] private PlayerTracker _playerTracker;
        [SerializeField] private SuckableDetector _suckableDetector;
        [SerializeField] private EntityHealth _entityHealth;
        [SerializeField] private float _count = 20;

        private ISuckTracker SuckTracker => _playerTracker.Suck;

        private void OnEnable()
        {
            SuckTracker.Sucking += OnSucking;
        }

        private void OnDisable()
        {
            SuckTracker.Sucking -= OnSucking;
        }

        public void OnSuckingInput()
        {
            if (SuckTracker.CanSuck == false)
                return;

            SuckTracker.StartSuck();
        }

        private void OnSucking()
        {
            int size = _suckableDetector.GetNearbyColliders(out IEnumerable<ISuckable> result);

            if (TryGetClosestSuckable(size, result, out ISuckable suckable) == false)
                return;

            _entityHealth.Heal(suckable.Damage(_count));
        }

        private bool TryGetClosestSuckable(int size, IEnumerable<ISuckable> suckables, out ISuckable closestSuckable)
        {
            closestSuckable = null;

            if (size == 0)
                return false;

            float closestDistance = float.MaxValue;

            foreach (ISuckable suckable in suckables)
            {
                float distance = GetDistanceTo(suckable);

                if (distance > closestDistance)
                    continue;

                closestDistance = distance;
                closestSuckable = suckable;
            }

            return true;
        }

        private float GetDistanceTo(ISuckable suckable)
        {
            return (suckable.Transform.position - transform.position).sqrMagnitude;
        }
    }
}