using Entity;
using Physics;
using UnityEngine;

namespace Player
{
    public class Attacker : MonoBehaviour, IAttacker, ITimerUser
    {
        [SerializeField] private float _damage;
        [SerializeField] private BoxColliderDetector _detector;

        public float Damage => 1;
        public Transform Transform => transform;

        public void Attack()
        {
            if (_detector.TryGetCollided(out IDamageable damageable) == false)
                return;

            damageable.Damage(this);
        }
    }
}