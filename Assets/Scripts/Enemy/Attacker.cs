using Enemy.Trackers;
using Entity;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    [RequireComponent(typeof(Enemy))]
    public class Attacker : MonoBehaviour, IAttacker
    {
        private const float MinDamage = 5;
        private const float MaxDamage = 15;

        private Enemy _enemy;

        public Transform Transform => _enemy.transform;
        private IAttackTracker AttackTracker => _enemy.EnemyTracker.Attack;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
        }

        public void Attack()
        {
            if (AttackTracker.CanAttack == false)
                return;

            AttackTracker.Attack();
            _enemy.Target.Damage(this, Random.Range(MinDamage, MaxDamage));
        }
    }
}