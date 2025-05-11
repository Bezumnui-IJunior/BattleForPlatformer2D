using System;
using Entity;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(EntityBattle))]
    public class KeyboardInput : MonoBehaviour, IInput
    {
        public event Action Jumping;
        public event Action Attacking;
        public event Action Sucking;

        public float HorizontalSpeed { get; private set; }

        private void Update()
        {
            const string HorizontalAxis = "Horizontal";
            const string JumpButton = "Jump";
            const int AttackButton = 0;
            const int SuckButton = 1;

            HorizontalSpeed = Input.GetAxisRaw(HorizontalAxis);

            if (Input.GetButton(JumpButton))
                Jumping?.Invoke();

            if (Input.GetMouseButtonDown(AttackButton))
                Attacking?.Invoke();

            if (Input.GetMouseButtonDown(SuckButton))
                Sucking?.Invoke();
        }
    }
}