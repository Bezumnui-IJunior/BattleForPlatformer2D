using Misc;
using UnityEngine;

namespace Enemy.States.Patrolling
{
    public class PatrollingMovement : MonoBehaviour, IToggle
    {
        [SerializeField] private Enemy _enemy;

        private void FixedUpdate()
        {
            if (_enemy.EnemyTracker.Movement.IsSafeToStep() == false)
            {
                if (_enemy.EntityTracker.Ground.IsGround == false)
                {
                    _enemy.Motion.GoWithSpeed(transform.right.x);

                    return;
                }

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