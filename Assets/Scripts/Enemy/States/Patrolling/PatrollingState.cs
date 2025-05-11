using Enemy.States.Following;
using Entity;
using Entity.States;
using UnityEngine;

namespace Enemy.States.Patrolling
{
    public class PatrollingState : State, ICoroutineExecutor
    {
        [SerializeField] private float _detectorDelaySeconds = 3;
        [SerializeField] private PatrollingMovement _movement;
        [SerializeField] private Enemy _enemy;

        private EnemyDetector _detector;

        protected override void Awake()
        {
            base.Awake();
            _detector = new EnemyDetector(this, _enemy.NearbyDetector, _detectorDelaySeconds);
        }

        public void OnEnable()
        {
            _movement.Enable();
            _detector.Enable();
            _detector.EnemyDetected += OnEnemyDetected;
        }

        public void OnDisable()
        {
            _detector.EnemyDetected -= OnEnemyDetected;
            _movement.Disable();
            _detector.Disable();
        }

        private void OnEnemyDetected(IDamageable damageable)
        {
            _enemy.Target = damageable;
            StateMachine.ChangeState<FollowingState>();
        }
    }
}