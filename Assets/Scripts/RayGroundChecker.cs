using System;
using UnityEngine;

public class RayGroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _raySize = 0.1f;
    [SerializeField] private LayerMask _groundMask;

    private RaycastHit2D[] _hits;

    private void Awake()
    {
        if (_groundCheck == null)
            throw new NullReferenceException("Ground Check must be set.");
        
    }

    public bool IsGrounded()
    {
        Vector3 direction = _groundCheck.position + Vector3.down;
        RaycastHit2D hit = Physics2D.Raycast(_groundCheck.position, direction, _raySize, _groundMask);

        return (bool) hit;
    }

}