using System.Collections.Generic;
using UnityEngine;

namespace Physics
{
    public class BoxColliderDetector : MonoBehaviour
    {
        [SerializeField] private Vector2 _size = Vector2.one;
        [SerializeField] private ContactFilter2D _filter;
        [SerializeField] private Color _gizmosColor = Color.blue;
        [SerializeField] private Collider2D _ignored;

        private readonly List<Collider2D> _colliders = new(10);

        public bool TryGetCollided<T>(out T component)
        {
            component = default;

            int size = Physics2D.OverlapBox(transform.position, _size, 0f, _filter, _colliders);

            for (int i = 0; i < size; i++)
            {
                Collider2D hit = _colliders[i];

                if (hit == _ignored)
                    continue;

                if (hit.TryGetComponent(out component))
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