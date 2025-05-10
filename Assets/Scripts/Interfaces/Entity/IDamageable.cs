using UnityEngine;

namespace Entity
{
    public interface IDamageable
    {
        public Transform Transform { get; }
        public void Damage(IAttacker attacker, float damage);
        public bool IsAlive { get; }
    }
}