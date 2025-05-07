using UnityEngine;

namespace Physics
{
    public class NearbyDetector : MonoBehaviour
    {
        [SerializeField] private float _radius = 10;
        [SerializeField] private ContactFilter2D _filter;
        [SerializeField] private Color _circleColor = Color.white;
        [SerializeField] private Color _colliderColor = Color.white;
        [SerializeField] private Vector3 _colliderShape = Vector3.one;

        private readonly Collider2D[] _colliders = new Collider2D[10];

        public int GetNearbyColliders(out Collider2D[] colliders)
        {
            colliders = _colliders;

            return Physics2D.OverlapCircle(transform.position, _radius, _filter, _colliders);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = _circleColor;
            Gizmos.DrawWireSphere(transform.position, _radius);
            Gizmos.color = _colliderColor;

            int size = GetNearbyColliders(out Collider2D[] colliders);

            for (int i = 0; i < size; i++)
            {
                Gizmos.DrawCube(colliders[i].ClosestPoint(transform.position), _colliderShape);
                Gizmos.DrawLine(colliders[i].ClosestPoint(transform.position), transform.position);
            }
        }
    }
}