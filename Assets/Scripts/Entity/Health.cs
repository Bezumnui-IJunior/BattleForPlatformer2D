using System;
using UnityEngine;

namespace Entity
{
    [RequireComponent(typeof(IDieProvider))]
    public class EntityHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private float _initialValue = 100;

        private IDieProvider _dieProvider;
        private float _value;

        public event Action<IAttacker> Damaged;

        private void Awake()
        {
            _dieProvider = GetComponent<IDieProvider>();
            _value = _initialValue;
        }

        public void Damage(IAttacker attacker)
        {
            if (attacker.Damage < 0)
                return;

            _value = Mathf.Max(_value - attacker.Damage, 0);

            Damaged?.Invoke(attacker);

            if (_value <= 0)
                _dieProvider.Die();

            Debug.Log($"hp: {_value}");
        }

        public void Damage(float damage)
        {
            throw new NotImplementedException();
        }
    }
}