using System;
using Entity.IState;
using Move;
using UnityEngine;

namespace Entity.State
{
    [Serializable]
    public class GroundedTracker : Tracker, IGroundedTracker
    {
        private GroundChecker _groundChecker;

        private bool _isGrounded;

        public event Action Grounded;

        public override void Update()
        {
            if (_groundChecker.IsGrounded())
            {
                if (_isGrounded == false)
                {
                    Debug.Log("Grounded");
                    Grounded?.Invoke();
                }

                _isGrounded = true;

                return;
            }

            _isGrounded = false;
        }

        public void Init(GroundChecker groundChecker)
        {
            _groundChecker = groundChecker;
            _isGrounded = _groundChecker.IsGrounded();
        }
    }
}