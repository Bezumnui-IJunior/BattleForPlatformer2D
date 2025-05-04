using System;
using UnityEngine;

namespace Player
{
    public class KeyboardInput : MonoBehaviour, IInput
    {
        public float HorizontalSpeed { get; private set; }
        public event Action Jumping;

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