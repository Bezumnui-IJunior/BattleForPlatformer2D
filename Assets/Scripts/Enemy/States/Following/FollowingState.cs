using System;
using Enemy.States.Patrolling;
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
        [SerializeField] private FollowingMovement _movement;
        [SerializeField] private Enemy _enemy;
        
        private IDamageable _target;
        private EnemyDetector _detector;
        private CooldownTimer _calmTimer;

        protected override void Awake()
        {
            base.Awake();
            _detector = new EnemyDetector(this, _enemy.NearbyDetector, _detectorDelaySeconds);
            _calmTimer = new CooldownTimer(this, _calmInvokeTimer);
        }

        private void OnEnable()
        {
            _detector.EnemyDetected += OnEnemyDetected;
            _calmTimer.Freed += OnCalmTimer;
            _detector.Enable();
            _target = _enemy.TakeTarget();
            _movement.Enable();
            
            _calmTimer.Start();
        }

        private void OnDisable()
        {
            _detector.EnemyDetected -= OnEnemyDetected;
            _calmTimer.Freed -= OnCalmTimer;

            _detector.Disable();
            _movement.Disable();
        }

        private void OnEnemyDetected(IDamageable damageable)
        {
            if (damageable == _target)
                _calmTimer.Restart();
        }

        private void OnCalmTimer()
        {
            Debug.Log("exit");
            StateMachine.ChangeState<PatrollingState>();
        }
    }
}