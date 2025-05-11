using System;
using System.Collections.Generic;
using Entity;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Collider2D))]
    public class AttackField : MonoBehaviour, IAttackField
    {
        [SerializeField] private Enemy _enemy;
        
        public bool IsContainTarget { get; private set; }
        public event Action TargetEntered;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable damageable) == false)
                return;

            if (_enemy.Target != damageable)
                return;

            IsContainTarget = true;
            TargetEntered?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable damageable) == false)
                return;

            if (_enemy.Target != damageable)
                return;

            IsContainTarget = false;
        }

      
    }
}