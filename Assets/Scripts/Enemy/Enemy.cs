using System;
using Enemy.Trackers;
using Entity;
using Entity.Trackers;
using Physics;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Entity.Entity))]
    [RequireComponent(typeof(EntityBattle))]
    public class Enemy : MonoBehaviour, IDieProvider
    {
        [SerializeField] private EnemyTracker _enemyTracker;
        [SerializeField] private EnemyNearbyDetector _nearbyDetector;
        [SerializeField] private AttackField _attackField;
        [SerializeField] private RayChecker _wallChecker;
        [SerializeField] private RayChecker _voidChecker;

        private Entity.Entity _entity;
        public IRotator Rotator => _entity.Rotator;
        public EnemyNearbyDetector NearbyDetector => _nearbyDetector;
        public EntityMotion Motion => _entity.Motion;
        public IAttackField AttackField => _attackField;
        public IEntityTracker EntityTracker => _entity.Tracker;
        public IEnemyTracker EnemyTracker => _enemyTracker;
        public IRayChecker WallChecker => _wallChecker;
        public IRayChecker VoidChecker => _voidChecker;
        public IEntityBattle EntityBattle { get; private set; }
        public IDamageable Target { get; set; }

        private void Awake()
        {
            _entity = GetComponent<Entity.Entity>();
            EntityBattle = GetComponent<EntityBattle>();
            _enemyTracker.Initialize();
        }

        private void OnValidate()
        {
            if (_nearbyDetector == null)
                throw new NullReferenceException($"{nameof(_nearbyDetector)} cannot be null");
        }

        public void Die()
        {
            Destroy(gameObject);
        }
    }
}