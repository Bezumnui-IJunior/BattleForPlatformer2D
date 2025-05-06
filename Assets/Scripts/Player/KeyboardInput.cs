using System;
using UnityEngine;

namespace Player
{
    public class KeyboardInput : MonoBehaviour, IInput
    {
        public event Action Jumping;

        public float HorizontalSpeed { get; private set; }

        private void Update()
        {
            const string HorizontalAxis = "Horizontal";
            const string JumpButton = "Jump";

            HorizontalSpeed = Input.GetAxisRaw(HorizontalAxis);

            if (Input.GetButton(JumpButton))
                Jumping?.Invoke();
        }
    }
}