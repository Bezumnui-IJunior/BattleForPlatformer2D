using Entity;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(StateTracker))]
    public class MoveAnimation : MonoBehaviour
    {
        private static readonly int IsWalkAnimation = Animator.StringToHash("IsWalk");
        private static readonly int IsJumpAnimation = Animator.StringToHash("IsJump");
        private static readonly int IsFallAnimation = Animator.StringToHash("IsFall");

        private Animator _animator;
        private IStateTracker _state;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _state = GetComponent<StateTracker>();
        }

        private void OnEnable()
        {
            _state.StartWalking += OnStartWalking;
            _state.StopWalking += OnStopWalking;
            _state.StartJumping += OnStartJumping;
            _state.StopJumping += OnStopJumping;
            _state.StartFalling += OnStartFalling;
            _state.StopFalling += OnStopFalling;
        }

        private void OnDisable()
        {
            _state.StartWalking -= OnStartWalking;
            _state.StopWalking -= OnStopWalking;
            _state.StartJumping -= OnStartJumping;
            _state.StopJumping -= OnStopJumping;
            _state.StartFalling -= OnStartFalling;
            _state.StopFalling -= OnStopFalling;
        }

        private void OnStartWalking(float _) =>
            _animator.SetBool(IsWalkAnimation, true);

        private void OnStopWalking() =>
            _animator.SetBool(IsWalkAnimation, false);

        private void OnStartJumping() =>
            _animator.SetBool(IsJumpAnimation, true);

        private void OnStopJumping() =>
            _animator.SetBool(IsJumpAnimation, false);

        private void OnStartFalling() =>
            _animator.SetBool(IsFallAnimation, true);

        private void OnStopFalling() =>
            _animator.SetBool(IsFallAnimation, false);
    }
}