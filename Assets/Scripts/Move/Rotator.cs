using UnityEngine;

namespace Move
{
    public class Rotator : MonoBehaviour, IRotator
    {
        private readonly Quaternion _leftRotation = Quaternion.Euler(new Vector3(0, 180, 0));
        private readonly Quaternion _rightRotation = Quaternion.identity;

        public void Toggle()
        {
            if (IsLookRight())
                LookLeft();
            else
                LookRight();
        }

        public void LookRight()
        {
            if (IsLookRight())
                return;

            transform.rotation = _rightRotation;
        }

        public void LookLeft()
        {
            if (IsLookRight() == false)
                return;

            transform.rotation = _leftRotation;
        }

        private bool IsLookRight()
        {
            return transform.right.x > 0;
        }
    }
}