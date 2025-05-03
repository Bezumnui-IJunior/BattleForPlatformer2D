using System;
using System.Collections;
using Entity;
using Misc;
using Physics;
using UnityEngine;

namespace Move
{
    public class Mover : MonoBehaviour, IMover
    {
        [SerializeField] private float _speed = 100;
        [SerializeField] private float _jumpForce = 10;
        [SerializeField] private float _cooldownSeconds = .2f;

        private GroundChecker _groundChecker;
        private Rigidbody2D _rigidbody;
        private Cooldown _cooldown;

        private bool _isMove;

        private void Awake()
        {
            _groundChecker = GetComponent<GroundChecker>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _cooldown = new Cooldown(this, _cooldownSeconds);
        }
        
        public void GoRight() =>
            SetSpeedByX(_speed);

        public void GoLeft() =>
            SetSpeedByX(-_speed);
        
        public void Stay() =>
            SetSpeedByX(0);


        public void Jump()
        {
            if (_groundChecker.IsGrounded() == false)
                return;

            if (_cooldown.IsFree == false)
                return;

            _cooldown.Accuse();

            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
        }

        private void SetSpeedByX(float speed)
        {
            Vector3 velocity = _rigidbody.linearVelocity;
            velocity.x = speed;
            _rigidbody.linearVelocity = velocity;
        }

    }
}