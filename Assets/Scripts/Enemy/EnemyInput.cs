using System;
using Move;
using Physics;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(IRotator))]
    public class EnemyInput : MonoBehaviour, IInput
    {
        [SerializeField] private WallCheck _wallCheck;
        
        private IRotator _rotator;

        public event Action GoingLeft;
        public event Action GoingRight;
        public event Action HorizontalStopping;
        public event Action Jumping;

        private void Awake()
        {
            _rotator = GetComponent<IRotator>();
        }

        private void Start()
        {
            GoingRight?.Invoke();
        }

        private void Update()
        {
            if (_wallCheck.IsWall())
            {
                _rotator.Toggle();
            }

            if (transform.right.x > 0)
                GoingRight?.Invoke();

            if (transform.right.x < 0)
                GoingLeft?.Invoke();
        }
    }
}