using System;
using UnityEngine;

namespace Player
{
    public class KeyboardInput : MonoBehaviour, IInput
    {
        public event Action GoingLeft;
        public event Action GoingRight;
        public event Action HorizontalStopping;
        public event Action Jumping;

        private void Update()
        {
            const string HorizontalAxis = "Horizontal";
            const string JumpButton = "Jump";

            float horizontalSpeed = Input.GetAxisRaw(HorizontalAxis);

            if (horizontalSpeed > 0)
                GoingRight?.Invoke();
            else if (horizontalSpeed < 0)
                GoingLeft?.Invoke();

            if (Input.GetButtonUp(HorizontalAxis))
            {
                HorizontalStopping?.Invoke();
            }

            if (Input.GetButton(JumpButton))
                Jumping?.Invoke();
        }
    }
}