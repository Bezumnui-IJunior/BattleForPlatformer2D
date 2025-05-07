using Entity;
using UnityEngine;

namespace Enemy.States.Following
{
    public class FollowingMovement : MonoBehaviour, IMovement
    {
        private const float RightSpeed = 1;

        [SerializeField] private Enemy _enemy;

        private EntityMotion Motion => _enemy.Motion;

        public float HorizontalSpeed { get; private set; }

        private void Start()
        {
            HorizontalSpeed = RightSpeed;
        }

        public void Enable() =>
            enabled = true;

        public void Disable() =>
            enabled = false;
    }
}