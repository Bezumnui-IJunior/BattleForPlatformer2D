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
        [SerializeField] private NearbyDetector _suckableDetector;
        [SerializeField] private PlayerTracker _tracker;
        [SerializeField] private HealthSucker _healthSucker;

        private Entity.Entity _entity;
        private IInput _input;

        public BoxColliderDetector EnemyDetector => _enemyDetector;

        public NearbyDetector SuckableDetector => _suckableDetector;

        public IPlayerTracker PlayerTracker => _tracker;

        private EntityMotion Motion => _entity.Motion;
        private EntityBattle _attacker;
        private Collider2D _collider;
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

        private void OnEnable()
        {
            _input.Jumping += Motion.OnJumping;
            _input.Attacking += _attacker.Attack;
            _input.Sucking += _healthSucker.OnSuckingInput;
        }

        private void Update()
        {
            Motion.GoWithSpeed(_input.HorizontalSpeed);
        }

        private void OnDisable()
        {
            _input.Jumping -= Motion.OnJumping;
            _input.Attacking -= _attacker.Attack;
            _input.Sucking -= _healthSucker.OnSuckingInput;
        }

        private void Destroy() =>
            Destroy(gameObject);

        public void Die()
        {
            Debug.Log("Player is dead");
            _collider.enabled = false;
            Invoke(nameof(Destroy), 2);
        }
    }
}