using System;
using Entity.IState;
using Move;
using UnityEngine;

namespace Entity.State
{
    [Serializable]
    public class WalkingTracker : Tracker, IWalkingTracker
    {
        private Rigidbody2D _rigidbody;
        private IMove _move;

        public event Action<float> StartWalking;
        public event Action StopWalking;

        public void Init(Rigidbody2D rigidbody, IMove move)
        {
            _rigidbody = rigidbody;
            _move = move;
        }

        public override void OnEnable()
        {
            _move.StopWalking += OnStopWalking;
            _move.StartWalking += OnStartWalking;
        }

        public override void OnDisable()
        {
            _move.StopWalking -= OnStopWalking;
            _move.StartWalking -= OnStartWalking;
        }

        public override void Update()
        {
        }

        private void OnStopWalking() =>
            StopWalking?.Invoke();

        private void OnStartWalking() =>
            StartWalking?.Invoke(_rigidbody.linearVelocityX);
    }
}