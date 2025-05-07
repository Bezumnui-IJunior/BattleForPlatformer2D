using Entity;
using Physics;
using UnityEngine;

namespace Enemy.States.Patrolling
{
    public class PatrollingMovement : MonoBehaviour, IMovement
    {
        private const float RightSpeed = 1;

        [SerializeField] private Enemy _enemy;
        [SerializeField] private WallChecker _wallChecker;

        private void Update()
        {
            if (_wallChecker.IsWall())
            {
                _enemy.Rotator.Toggle();
                _enemy.Motion.Jump();
            }

            _enemy.Motion.GoWithSpeed(transform.right.x);
        }

        public void Enable() =>
            enabled = true;

        public void Disable() =>
            enabled = false;
    }
}