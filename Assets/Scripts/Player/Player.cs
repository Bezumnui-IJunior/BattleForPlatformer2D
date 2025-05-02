using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(GroundChecker))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        private GroundChecker _groundChecker;
        public Rigidbody2D Rigidbody { get; private set; }

        private void Awake()
        {
            _groundChecker = GetComponent<GroundChecker>();
            Rigidbody = GetComponent<Rigidbody2D>();
        }

        public bool IsGrounded()
        {
            return _groundChecker.IsGrounded();
        }
    }
}