using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Entity.Entity))]
    [RequireComponent(typeof(EnemyMovement))]
    public class Enemy : MonoBehaviour
    {
        private Entity.Entity _entity;
        private EnemyMovement _movement;
        public IRotator Rotator => _entity.Rotator;

        private void Awake()
        {
            _entity = GetComponent<Entity.Entity>();
            _movement = GetComponent<EnemyMovement>();
        }

        private void OnEnable() =>
            _movement.Jumping += _entity.Motion.OnJumping;

        private void Update() =>
            _entity.Motion.GoWithSpeed(_movement.HorizontalSpeed);

        private void OnDisable() =>
            _movement.Jumping -= _entity.Motion.OnJumping;
    }
}