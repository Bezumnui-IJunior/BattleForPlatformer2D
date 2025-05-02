using System;
using UnityEngine;

namespace Player
{
    public class Move : MonoBehaviour
    {
        [SerializeField] private float _speed = 100;
        [SerializeField] private float _jumpForce = 10;
        [SerializeField] private float _cooldownSeconds = .2f;

        private Rotator _rotator;
        private Player _player;
        private Rigidbody2D _rigidbody;
        private Cooldown _cooldown;

        private bool _isMove;

        public event Action StartWalking;
        public event Action StopWalking;
        public event Action StartJumping;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _cooldown = new Cooldown(_cooldownSeconds);
            _rotator = new Rotator(transform);
        }

        public void Stay() =>
            SetSpeedByX(0);

        public void GoRight() =>
            SetSpeedByX(_speed);

        public void GoLeft() =>
            SetSpeedByX(-_speed);

        public void Jump()
        {
            if (_player.IsGrounded() == false)
                return;

            if (_cooldown.IsFree == false)
                return;

            StartCoroutine(_cooldown.Accuse());

            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
            StartJumping?.Invoke();
        }

        private void SetSpeedByX(float speed)
        {
            Vector3 velocity = _rigidbody.linearVelocity;
            velocity.x = speed;
            _rigidbody.linearVelocity = velocity;
            _rotator.RotateByDirection(speed);

            InvokeMoving(speed);
        }

        private void InvokeMoving(float speed)
        {
            if (speed == 0)
            {
                if (_isMove)
                    StopWalking?.Invoke();

                _isMove = false;

                return;
            }

            if (_isMove == false)
                StartWalking?.Invoke();

            _isMove = true;
        }
    }
}