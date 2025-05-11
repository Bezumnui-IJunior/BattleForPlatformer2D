using Entity;
using Physics;
using Player.Trackers;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Entity.Entity))]
    [RequireComponent(typeof(IInput))]
    [RequireComponent(typeof(Collider2D))]
    public class Player : MonoBehaviour, IDieProvider
    {
        [SerializeField] private BoxColliderDetector _enemyDetector;
        [SerializeField] private PlayerTracker _tracker;
        [SerializeField] private HealthSucker _healthSucker;
        private EntityBattle _attacker;
        private Collider2D _collider;

        private Entity.Entity _entity;
        private IInput _input;

        public BoxColliderDetector EnemyDetector => _enemyDetector;
        public IPlayerTracker PlayerTracker => _tracker;
        private EntityMotion Motion => _entity.Motion;

        public EntityHealth EntityHealth { get; private set; }

        private void Awake()
        {
            _entity = GetComponent<Entity.Entity>();
            _input = GetComponent<IInput>();
            _collider = GetComponent<Collider2D>();
            _attacker = GetComponent<EntityBattle>();
            EntityHealth = GetComponent<EntityHealth>();

            _tracker.Initialize();
        }

        private void Update()
        {
            Motion.GoWithSpeed(_input.HorizontalSpeed);
        }

        private void OnEnable()
        {
            _input.Jumping += Motion.OnJumping;
            _input.Attacking += _attacker.Attack;
            _input.Sucking += _healthSucker.OnSuckingInput;
        }

        private void OnDisable()
        {
            _input.Jumping -= Motion.OnJumping;
            _input.Attacking -= _attacker.Attack;
            _input.Sucking -= _healthSucker.OnSuckingInput;
        }

        public void Die()
        {
            _collider.enabled = false;
            Invoke(nameof(Destroy), 2);
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}