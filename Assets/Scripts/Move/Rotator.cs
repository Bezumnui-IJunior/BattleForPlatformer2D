using Entity.IState;
using UnityEngine;

namespace Move
{
    public class Rotator : MonoBehaviour
    {
        private readonly Quaternion _rightRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        private readonly Quaternion _leftRotation = Quaternion.Euler(new Vector3(0, 180, 0));

        private IStateTracker _state;

        private bool _isLookRight;

        private void Awake()
        {
            _state = GetComponent<IStateTracker>();
        }

        private void OnEnable()
        {
            _state.WalkingTracker.StartWalking += OnStartWalking;
        }

        private void OnDisable()
        {
            _state.WalkingTracker.StartWalking -= OnStartWalking;
        }

        private void OnStartWalking(float speed)
        {
            if (speed > 0)
                LookRight();
            else
                LookLeft();
        }

        private void LookRight()
        {
            if (_isLookRight)
                return;

            transform.rotation = _rightRotation;

            _isLookRight = true;
        }

        private void LookLeft()
        {
            if (_isLookRight == false)
                return;

            transform.rotation = _leftRotation;

            _isLookRight = false;
        }
    }
}