using UnityEngine;

namespace Physics
{
    public class BoxGroundChecker : MonoBehaviour
    {
        [SerializeField] private Vector2 _boxSize;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private Color _gizmosColor;
    
        private RaycastHit2D[] _hits;
    
        public bool IsGrounded()
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position, _boxSize, 0, _groundMask.value);
        
            return (bool) hit;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = _gizmosColor;
            Gizmos.DrawWireCube(transform.position, _boxSize);
        }
    }
}