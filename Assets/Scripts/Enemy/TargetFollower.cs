using UnityEngine;

namespace Enemy
{
    public class TargetFollower : MonoBehaviour
    {
        private Transform _target;

        private void Follow(Transform target)
        {
            _target = target;
        }
    }
}