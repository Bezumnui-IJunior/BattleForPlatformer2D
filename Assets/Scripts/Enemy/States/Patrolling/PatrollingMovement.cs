using Entity;
using Misc;
using Physics;
using UnityEngine;

namespace Enemy.States.Patrolling
{
    public class PatrollingMovement : MonoBehaviour, IToggle
    {
        [SerializeField] private Enemy _enemy;

        private void Update()
        {
            if (_enemy.WallChecker.IsWall())
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