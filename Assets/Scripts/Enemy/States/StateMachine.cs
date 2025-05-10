using System;
using System.Collections.Generic;
using Enemy.States.Following;
using Enemy.States.Patrolling;
using Entity.States;
using UnityEngine;

namespace Enemy.States
{
    public class StateMachine : MonoBehaviour, IStateMachine
    {
        private State _currentState;
        private State _patrolling;
        private State _followingTarget;

        private Dictionary<Type, State> _states;

        private void Awake()
        {
            _patrolling = GetComponent<PatrollingState>();
            _followingTarget = GetComponent<FollowingState>();

            _states = new Dictionary<Type, State>
            {
                [typeof(PatrollingState)] = _patrolling,
                [typeof(FollowingState)] = _followingTarget
            };
        }

        private void OnEnable()
        {
            SetDefaultState();
        }

        public void ChangeState<T>() where T : State
        {
            if (_currentState)
                _currentState.Exit();

            if (_states.TryGetValue(typeof(T), out State state) == false)
                throw new KeyNotFoundException($"Please update {nameof(StateMachine)} with {nameof(T)}.");

            _currentState = state;
            state.Occupy();
        }

        private void SetDefaultState() =>
            ChangeState<PatrollingState>();
    }
}