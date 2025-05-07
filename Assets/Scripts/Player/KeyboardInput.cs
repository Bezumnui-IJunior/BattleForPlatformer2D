using System;
using Entity;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(EntityAttack))]
    public class KeyboardInput : MonoBehaviour, IInput
    {
        private IEntityAttack _attacker;
        public event Action Jumping;

        public float HorizontalSpeed { get; private set; }

        private void Awake()
        {
            _attacker = GetComponent<EntityAttack>();
        }

        private void Update()
        {
            const string HorizontalAxis = "Horizontal";
            const string JumpButton = "Jump";
            const int AttackButton = 0;

            HorizontalSpeed = Input.GetAxisRaw(HorizontalAxis);
            if (Input.GetButton(JumpButton))
                Jumping?.Invoke();

            if (Input.GetMouseButtonDown(AttackButton))
                _attacker.Attack();
        }
    }
}