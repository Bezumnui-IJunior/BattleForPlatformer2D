using UnityEngine;

namespace Enemy.Trackers
{
    public class EnemyTracker : MonoBehaviour, ICoroutineExecutor, IEnemyTracker
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private float _attackCooldownSeconds;

        private AttackTracker _attackTracker;
        private MovementTracker _movementTracker;

        private void OnEnable()
        {
            _attackTracker.Enable();
        }

        private void OnDisable()
        {
            _attackTracker.Disable();
        }

        public IAttackTracker Attack => _attackTracker;
        public IMovementTracker Movement => _movementTracker;

        public void Initialize()
        {
            _attackTracker = new AttackTracker(this, _attackCooldownSeconds, _enemy.AttackField);
            _movementTracker = new MovementTracker(_enemy);
        }
    }
}