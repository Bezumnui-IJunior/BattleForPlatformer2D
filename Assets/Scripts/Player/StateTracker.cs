using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Move))]
    [RequireComponent(typeof(Player))]
    public class StateTracker : MonoBehaviour, IStateTracker
    {
        [SerializeField] public float _groundCheckCooldown = 0.2f;
        [SerializeField] private float _fallThreshold = 0.01f;

        private Player _player;

        private Move _move;
        private bool _isLastFall;
        private bool _isJump;
        private float _jumpTime;

        public event Action StartFalling;
        public event Action StopFalling;
        public event Action StartJumping;
        public event Action StopJumping;
        public event Action StartWalking;
        public event Action StopWalking;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _move = GetComponent<Move>();
        }

        private void OnEnable()
        {
            _move.StartWalking += OnStartWalking;
            _move.StopWalking += OnStopWalking;
            _move.StartJumping += OnStartJumping;
        }

        private void Update()
        {
            UpdateFall();
            UpdateJump();
        }

        private void OnDisable()
        {
            _move.StartWalking -= OnStartWalking;
            _move.StopWalking -= OnStopWalking;
            _move.StartJumping -= OnStartJumping;
        }

        private void UpdateFall()
        {
            bool isFall = IsFall();

            if (_isLastFall == false && isFall)
                StartFalling?.Invoke();
            else if (_isLastFall && isFall == false)
                StopFalling?.Invoke();

            _isLastFall = isFall;
        }

        private void UpdateJump()
        {
            if (_isJump && IsFall())
            {
                StopJump();
            }

            else if (_isJump && _player.IsGrounded())
            {
                if (Time.realtimeSinceStartup > _jumpTime + _groundCheckCooldown)
                    StopJump();
            }
        }

        private bool IsFall() =>
            _player.Rigidbody.linearVelocityY < -_fallThreshold;

        private void StopJump()
        {
            _isJump = false;
            StopJumping?.Invoke();
        }

        private void OnStartJumping()
        {
            _isJump = true;
            _jumpTime = Time.realtimeSinceStartup;
            StartJumping?.Invoke();
        }

        private void OnStopWalking() =>
            StopWalking?.Invoke();

        private void OnStartWalking() =>
            StartWalking?.Invoke();
    }
}