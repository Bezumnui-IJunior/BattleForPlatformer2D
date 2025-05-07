using Entity;
using Physics;
using UnityEngine;

namespace Player
{
    public class Attacker : IAttacker
    {
        private readonly BoxColliderDetector _detector;
        private readonly float _damage = 5;

        public Transform Transform { get; }

        public Attacker(BoxColliderDetector detector, Transform transform)
        {
            _detector = detector;
            Transform = transform;
        }

        public void Attack()
        {
            if (_detector.TryGetCollided(out IDamageable damageable) == false)
                return;

            damageable.Damage(this, _damage);
        }
    }
}