using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Move))]
    public class KeyboardMove : MonoBehaviour
    {
        private Move _move;

        private void Awake()
        {
            _move = GetComponent<Move>();
        }

        private void Update()
        {
            const string HorizontalAxis = "Horizontal";
            const string JumpButton = "Jump";

            float horizontalSpeed = Input.GetAxisRaw(HorizontalAxis);

            if (horizontalSpeed > 0)
                _move.GoRight();
            else if (horizontalSpeed < 0)
                _move.GoLeft();
            else
                _move.Stay();

            if (Input.GetButton(JumpButton))
                _move.Jump();
        }
    }
}