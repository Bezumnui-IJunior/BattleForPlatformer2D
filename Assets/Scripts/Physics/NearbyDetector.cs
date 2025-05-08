using System.Collections.Generic;
using UnityEngine;

namespace Physics
{
    public class NearbyDetector : MonoBehaviour
    {
        [SerializeField] private float _radius = 10;
        [SerializeField] private ContactFilter2D _filter;
        [SerializeField] private Collider2D _ignoreCollider;
        [Header("Gizmos")] 
        [SerializeField] private Color _circleColor = Color.white;
        [SerializeField] private Color _colliderColor = Color.white;
        [SerializeField] private Vector3 _colliderShape = Vector3.one;

        private readonly Collider2D[] _colliders = new Collider2D[10];
        private List<Collider2D> _gizmosColliders = new(10);

        public void GetNearbyColliders<T>(ref List<T> colliders)
        {
            colliders.Clear();
            int size = Physics2D.OverlapCircle(transform.position, _radius, _filter, _colliders);

            for (int i = 0; i < size; i++)
            {
                Collider2D detected = _colliders[i];
                
                if (detected == _ignoreCollider)
                    continue;
                
                if (_colliders[i].TryGetComponent(out T component))
                    colliders.Add(component);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = _circleColor;
            Gizmos.DrawWireSphere(transform.position, _radius);
            Gizmos.color = _colliderColor;

            GetNearbyColliders(ref _gizmosColliders);

            foreach (Collider2D gizmosCollider in _gizmosColliders)
            {
                Gizmos.DrawCube(gizmosCollider.ClosestPoint(transform.position), _colliderShape);
                Gizmos.DrawLine(gizmosCollider.ClosestPoint(transform.position), transform.position);
            }
        }
    }
}