using UnityEngine;

namespace Enemy.Trackers
{
    public class EnemyTracker : MonoBehaviour, ICoroutineExecutor, IEnemyTracker
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private float _attackCooldownSeconds;

        private AttackTracker _attackTracker;
        public IAttackTracker AttackTracker => _attackTracker;

        public void Initialize()
        {
            _attackTracker = new AttackTracker(this, _attackCooldownSeconds, _enemy.AttackField);
        }

        private void OnEnable()
        {
            _attackTracker.Enable();
        }

        private void OnDisable()
        {
            _attackTracker.Disable();
        }
    }
}