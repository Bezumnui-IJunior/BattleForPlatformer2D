using Enemy.States.Following;
using Entity.States;
using UnityEngine;

namespace Enemy.States
{
    [RequireComponent(typeof(Enemy))]
    public class StateMachine : MonoBehaviour, IStateDescriptor
    {
        private IState _currentState;

        private IState _patrolling;
        private IState _followingTarget;
        private Enemy _enemy;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
            
            _patrolling = new Patrolling.Patrolling();
            _followingTarget = new Following.Following();
            _currentState = _patrolling;
        }

        private void OnEnable()
        {
            _patrolling.OnExited += OnPatrollingExited;
            _followingTarget.OnExited += OnFollowingTargetExited;
        }

        private void Update()
        {
            _currentState.Update();
        }

        private void OnDisable()
        {
            _patrolling.OnExited -= OnPatrollingExited;
            _followingTarget.OnExited -= OnFollowingTargetExited;
        }

        private void OnPatrollingExited()
        {
        }

        private void OnFollowingTargetExited()
        {
        }
    }
}