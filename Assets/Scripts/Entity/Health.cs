﻿using System;
using UI.View;
using UnityEngine;

namespace Entity
{
    [RequireComponent(typeof(IDieProvider))]
    public class EntityHealth : MonoBehaviour, IDamageable, IHealable, IChangeableValue
    {
        [SerializeField] private float _maxHealth = 100;

        private IDieProvider _dieProvider;
        public float Value { get; private set; }
        public float MaxValue { get; private set; }
        public float MinValue => 0;
        public event Action Decreased;
        public event Action Increased;
        public event Action Initiated;
        public bool IsAlive => Value > 0;
        public Transform Transform => transform;
        public event Action<IAttacker> Damaged;

        private void Awake()
        {
            _dieProvider = GetComponent<IDieProvider>();
            MaxValue = _maxHealth;
            Value = _maxHealth;
            Initiated?.Invoke();
        }

        public void Damage(IAttacker attacker, float damage)
        {
            if (TryDecreaseHealth(damage) == false)
                return;

            Damaged?.Invoke(attacker);

            if (Value <= MinValue)
                _dieProvider.Die();
        }
        
        public void Heal(float amount)
        {
            Value = Mathf.Min(Value + amount, MaxValue);
            Increased?.Invoke();
        }

        private bool TryDecreaseHealth(float value)
        {
            if (value < MinValue)
                return false;

            Value = Mathf.Max(Value - value, MinValue);
            Decreased?.Invoke();

            return true;
        }

       
    }
}