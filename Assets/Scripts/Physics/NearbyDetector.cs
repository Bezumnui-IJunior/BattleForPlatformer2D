using System.Collections.Generic;
using UnityEngine;

namespace Physics
{
    public abstract class NearbyDetector<T> : MonoBehaviour
    {
        private const int MaxSize = 10;
        [SerializeField] private float _radius = 10;
        [SerializeField] private ContactFilter2D _filter;
        [SerializeField] private Collider2D _ignoreCollider;
        [Header("Gizmos")] [SerializeField] private Color _circleColor = Color.white;
        [SerializeField] private Color _colliderColor = Color.white;
        [SerializeField] private Vector3 _colliderShape = Vector3.one;

        private readonly Collider2D[] _colliders = new Collider2D[MaxSize];
        private readonly List<T> _components = new(MaxSize);

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = _circleColor;
            Gizmos.DrawWireSphere(transform.position, _radius);
            Gizmos.color = _colliderColor;

            GetNearbyColliders(out IEnumerable<T> components);

            foreach (T component in components)
            {
                if (component is MonoBehaviour monoBehaviourComponent == false)
                    return;

                if (monoBehaviourComponent.TryGetComponent(out Collider2D gameObjectCollider) == false)
                    continue;

                Gizmos.DrawCube(gameObjectCollider.ClosestPoint(transform.position), _colliderShape);
                Gizmos.DrawLine(gameObjectCollider.ClosestPoint(transform.position), transform.position);
            }
        }

        public int GetNearbyColliders(out IEnumerable<T> result)
        {
            _components.Clear();

            int size = Physics2D.OverlapCircle(transform.position, _radius, _filter, _colliders);
            int resultSize = 0;

            for (int i = 0; i < size; i++)
            {
                Collider2D detected = _colliders[i];

                if (detected == _ignoreCollider)
                    continue;

                if (_colliders[i].TryGetComponent(out T component) == false)
                    continue;

                _components.Add(component);
                resultSize++;
            }

            result = _components;

            return resultSize;
        }
    }
}