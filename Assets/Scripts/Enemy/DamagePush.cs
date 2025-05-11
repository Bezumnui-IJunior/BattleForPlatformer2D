using Entity;
using Misc;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EntityHealth))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(IMover))]
    public class DamagePush : MonoBehaviour, ICoroutineExecutor
    {
        [SerializeField] private Vector2 _directionForce;
        [SerializeField] private float _freezeSeconds = 0.5f;
        private CooldownTimer _freezeTimer;

        private EntityHealth _health;

        private IMover _mover;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _health = GetComponent<EntityHealth>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _mover = GetComponent<IMover>();
            _freezeTimer = new CooldownTimer(this, _freezeSeconds);
        }

        private void OnEnable()
        {
            _health.Damaged += OnDamage;
            _freezeTimer.Freed += _mover.Enable;
        }

        private void OnDisable()
        {
            _health.Damaged -= OnDamage;
            _freezeTimer.Freed -= _mover.Enable;
        }

        private void OnDamage(IAttacker attacker)
        {
            _rigidbody.linearVelocity = _directionForce;
            _rigidbody.linearVelocityX *= attacker.Transform.right.x;
            _mover.Disable();
            _freezeTimer.Start();
        }
    }
}