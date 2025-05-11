using Entity;
using UnityEngine;

namespace Player
{
    public class Attacker : MonoBehaviour, IAttacker
    {
        private const float Damage = 5;

        private Player _player;
        public Transform Transform => _player.transform;

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        public void Attack()
        {
            if (_player.EnemyDetector.TryGetCollided(out IDamageable damageable) == false)
                return;

            damageable.Damage(this, Damage);
        }
    }
}