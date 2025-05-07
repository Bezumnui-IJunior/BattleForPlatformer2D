using System;
using Enemy.States;
using Entity;
using Physics;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Entity.Entity))]
    [RequireComponent(typeof(Entity.Entity))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private StateMachine _stateMachine;
        [SerializeField] private NearbyDetector _nearbyDetector;

        private Entity.Entity _entity;
        public IRotator Rotator => _entity.Rotator;
        public NearbyDetector NearbyDetector => _nearbyDetector;
        public EntityMotion Motion => _entity.Motion;
        public IDamageable Target { private get; set; }

        private void Awake()
        {
            _entity = GetComponent<Entity.Entity>();
        }

        private void OnValidate()
        {
            if (_stateMachine == null)
                throw new NullReferenceException($"{nameof(_stateMachine)} cannot be null");

            if (_nearbyDetector == null)
                throw new NullReferenceException($"{nameof(_nearbyDetector)} cannot be null");
        }

        public IDamageable TakeTarget()
        {
            IDamageable target = Target;
            Target = null;

            return target;
        }
    }
}