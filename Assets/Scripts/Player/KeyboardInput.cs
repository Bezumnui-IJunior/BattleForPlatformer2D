using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Attacker))]
    public class KeyboardInput : MonoBehaviour, IInput
    {
        private Attacker _attacker;
        public event Action Jumping;

        public float HorizontalSpeed { get; private set; }

        private void Awake()
        {
            _attacker = GetComponent<Attacker>();
        }

        private void Update()
        {
            const string HorizontalAxis = "Horizontal";
            const string JumpButton = "Jump";

            HorizontalSpeed = Input.GetAxisRaw(HorizontalAxis);

            if (Input.GetButton(JumpButton))
                Jumping?.Invoke();

            if (Input.GetMouseButtonDown(1))
                _attacker.Attack();
        }
    }
}