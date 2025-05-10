using JetBrains.Annotations;
using UnityEngine;

namespace Physics
{
    public class BoxGroundChecker : MonoBehaviour
    {
        [SerializeField] private Vector2 _size;
        [SerializeField] private ContactFilter2D _filter;
        [SerializeField] private Color _gizmosColor;

        [SerializeField, Header("Optional"), CanBeNull]
        private Collider2D _ignoredCollider;

        private readonly Collider2D[] _collidersResults = new Collider2D[2];

        public bool IsGrounded()
        {
            int size = Physics2D.OverlapBox(transform.position, _size, 0, _filter, _collidersResults);

            if (size == 0)
                return false;

            for (int i = 0; i < size; i++)
            {
                if (_collidersResults[i] != _ignoredCollider)
                    return true;
            }

            return false;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = _gizmosColor;
            Gizmos.DrawWireCube(transform.position, _size);
        }
    }
}