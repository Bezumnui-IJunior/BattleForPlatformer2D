using System;
using Physics;
using UnityEngine;

namespace Enemy.States.Following
{
    [RequireComponent(typeof(Entity.Entity))]
    public class FollowingMovement : MonoBehaviour, IInput
    {
        private const float RightSpeed = 1;

        [SerializeField] private WallChecker _wallChecker;

        private Enemy _entity;
        public event Action Jumping;

        public float HorizontalSpeed { get; private set; }

        private void Awake()
        {
            _entity = GetComponent<Enemy>();
        }

        private void Start()
        {
            HorizontalSpeed = RightSpeed;
        }

        private void Update()
        {
            if (_wallChecker.IsWall())
            {
                _entity.Rotator.Toggle();
                Jumping?.Invoke();
            }

            HorizontalSpeed = transform.right.x;
        }
    }
}