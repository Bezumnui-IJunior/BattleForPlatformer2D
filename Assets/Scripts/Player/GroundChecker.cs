using System;
using UnityEngine;

namespace Player
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private BoxGroundChecker _groundChecker;
        [SerializeField] private BoxGroundChecker _groundExcluder;

        private void OnValidate()
        {
            if (_groundChecker == null)
                throw new NullReferenceException($"{nameof(_groundChecker)} cannot be null");

            if (_groundExcluder == null)
                throw new NullReferenceException($"{nameof(_groundExcluder)} cannot be null");
        }

        public bool IsGrounded()
        {
            return _groundChecker.IsGrounded() && _groundExcluder.IsGrounded() == false;
        }
    }
}