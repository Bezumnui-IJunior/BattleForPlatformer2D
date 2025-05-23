﻿using UnityEngine;

namespace Physics
{
    public class RayChecker : MonoBehaviour, IRayChecker
    {
        [SerializeField] private float _raySize = 1;
        [SerializeField] private LayerMask _mask;
        [SerializeField] private Color _gizmosNothingColor = Color.green;
        [SerializeField] private Color _gizmosDetectedColor = Color.red;

        public bool IsObstacle()
        {
            return Physics2D.Raycast(transform.position, transform.right, _raySize, _mask.value);
        }

        private void OnDrawGizmos()
        {
            if (IsObstacle())
                Gizmos.color = _gizmosDetectedColor;
            else
                Gizmos.color = _gizmosNothingColor;

            Gizmos.DrawLine(transform.position, transform.position + transform.right * _raySize);
        }
    }
}