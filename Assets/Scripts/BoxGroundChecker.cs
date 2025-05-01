using System;
using UnityEngine;

public class BoxGroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private LayerMask _groundMask;

    private RaycastHit2D[] _hits;

    private void Awake()
    {
        if (_groundCheck == null)
            throw new NullReferenceException("Ground Check must be set.");
        
    }

    public bool IsGrounded()
    {
        Collider2D hit = Physics2D.OverlapBox(_groundCheck.position, _boxSize, 0, _groundMask);
        
        return (bool) hit;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(_groundCheck.position, _boxSize);
    }
}