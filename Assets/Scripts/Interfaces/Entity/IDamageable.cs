using UnityEngine;

namespace Entity
{
    public interface IDamageable
    {
        public Transform Transform { get; }
        public bool IsAlive { get; }

        public void Damage(IAttacker attacker, float damage);
    }
}