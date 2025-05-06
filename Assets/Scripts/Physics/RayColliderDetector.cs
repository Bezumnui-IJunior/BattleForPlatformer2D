using System;
using UnityEngine;

namespace Physics
{
    public class RayColliderDetector : MonoBehaviour
    {
        [SerializeField] private float _raySize = 1;
        [SerializeField] private Color _gizmosColor = Color.blue;
        public bool TryGetCollided<T>(out T component)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, _raySize);

            return hit.transform.TryGetComponent(out component);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = _gizmosColor;

            Gizmos.DrawLine(transform.position, transform.position + transform.right * _raySize);
        }
    }
}