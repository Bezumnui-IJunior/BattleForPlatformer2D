using System;
using System.Collections.Generic;
using Entity;
using Player.Trackers;
using UnityEngine;

namespace Player
{
    public class HealthSucker : MonoBehaviour, ICoroutineExecutor
    {
        [SerializeField] private Player _player;
        [SerializeField] private float _count = 20;

        private List<ISuckable> _suckableList = new(10);

        private ISuckTracker SuckTracker => _player.PlayerTracker.Suck;

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
            _player.SuckableDetector.GetNearbyColliders(ref _suckableList);
            Debug.Log("Looking for target");

            if (TryGetClosestSuckable(out ISuckable suckable) == false)
                return;

            ;
            _player.EntityHealth.Heal(suckable.TakeHealth(_count));
            Debug.Log("Suck");
        }

        private bool TryGetClosestSuckable(out ISuckable closestSuckable)
        {
            closestSuckable = null;

            if (_suckableList.Count == 0)
                return false;

            closestSuckable = _suckableList[0];
            float closestDistance = GetDistanceTo(closestSuckable);

            for (int i = 1; i < _suckableList.Count; i++)
            {
                ISuckable suckable = _suckableList[i];
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
            return Vector3.Distance(suckable.Transform.position, transform.position);
        }
    }
}