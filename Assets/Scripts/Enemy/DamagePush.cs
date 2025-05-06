using Entity;
using Entity.Trackers;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EntityHealth))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(IMover))]
    [RequireComponent(typeof(IStateTracker))]
    public class DamagePush : MonoBehaviour
    {
        [SerializeField] private Vector2 _directionForce;

        private EntityHealth _health;
        private Rigidbody2D _rigidbody;
        private IStateTracker _tracker;
        private IMover _mover;

        private void Awake()
        {
            _health = GetComponent<EntityHealth>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _tracker = GetComponent<IStateTracker>();
            _mover = GetComponent<IMover>();
        }

        private void OnEnable()
        {
            _health.Damaged += OnDamage;
            _tracker.GroundedTracker.Grounded += OnGrounded;
        }

        private void OnDisable()
        {
            _health.Damaged -= OnDamage;
            _tracker.GroundedTracker.Grounded -= OnGrounded;
        }

        private void OnDamage(IAttacker attacker)
        {
            _rigidbody.linearVelocity = _directionForce;
            _rigidbody.linearVelocityX *= attacker.Transform.right.x;
            _mover.Disable();
        }

        private void OnGrounded()
        {
            _mover.Enable();
        }
    }
}