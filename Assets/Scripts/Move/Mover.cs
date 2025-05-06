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
        private CooldownTimer _cooldownTimer;

        private bool _isMove;

        private void Awake()
        {
            _groundChecker = GetComponent<GroundChecker>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _cooldownTimer = new CooldownTimer(this, _cooldownSeconds);
        }

        public void SetSpeedByX(float speed) =>
            _rigidbody.linearVelocityX = speed * _speed;

        public void Jump()
        {
            if (_groundChecker.IsGrounded() == false)
                return;

            if (_cooldownTimer.IsFree == false)
                return;

            _cooldownTimer.Accuse();
            _rigidbody.linearVelocityY = 0;
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}