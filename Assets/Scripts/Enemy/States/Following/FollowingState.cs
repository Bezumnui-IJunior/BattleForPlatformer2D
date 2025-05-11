using System.Collections.Generic;
using Entity;
using Entity.States;
using Misc;
using UnityEngine;

namespace Enemy.States.Following
{
    public class FollowingState : State, ICoroutineExecutor
    {
        [SerializeField] private float _detectorDelaySeconds = 1;
        [SerializeField] private float _calmInvokeTimer = 3;
        [SerializeField] private float _attackDelay = 0.4f;
        [SerializeField] private FollowingMovement _movement;
        [SerializeField] private Enemy _enemy;
        
        private CalmTimer _calmTimer;
        private EnemyDetector _detector;
        private IDamageable _target;

        private List<IToggle> _toggles;

        protected override void Awake()
        {
            base.Awake();
            _detector = new EnemyDetector(this, _enemy.NearbyDetector, _detectorDelaySeconds);
            _calmTimer = new CalmTimer(new CooldownTimer(this, _calmInvokeTimer), StateMachine);

            _toggles = new List<IToggle>
            {
                _detector,
                _movement,
                _calmTimer,
                new Battle(_enemy, new CooldownTimer(this, _attackDelay))
            };
        }

        private void OnEnable()
        {
            _target = _enemy.Target;

            _detector.EnemyDetected += OnEnemyDetected;

            foreach (IToggle toggle in _toggles)
                toggle.Enable();
        }

        private void OnDisable()
        {
            _detector.EnemyDetected -= OnEnemyDetected;

            foreach (IToggle toggle in _toggles)
                toggle.Disable();
        }

        private void OnEnemyDetected(IDamageable damageable)
        {
            if (damageable == _target)
                _calmTimer.Restart();
        }
    }
}