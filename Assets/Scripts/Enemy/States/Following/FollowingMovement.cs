using Entity;
using Misc;
using UnityEngine;

namespace Enemy.States.Following
{
    public class FollowingMovement : MonoBehaviour, IToggle
    {
        private const float RightSpeed = 1;
        private const float LeftSpeed = -1;

        [SerializeField] private Enemy _enemy;

        private EntityMotion Motion => _enemy.Motion;

        private void Update()
        {
            if (_enemy.Target.IsAlive == false)
                return;

            Vector3 direction = _enemy.Target.Transform.position - transform.position;

            if (_enemy.WallChecker.IsWall())
            {
                Motion.Jump();
                return;
            }
            
            if (direction.x > 0)
                Motion.GoWithSpeed(RightSpeed);
            else
                Motion.GoWithSpeed(LeftSpeed);
        }

        public void Enable() =>
            enabled = true;

        public void Disable() =>
            enabled = false;
    }
}