using UnityEngine;

namespace Entity
{
    [RequireComponent(typeof(Animator))]
    public class EntityAnimator : MonoBehaviour, IEntityAnimator
    {
        private static readonly int IsWalkAnimation = Animator.StringToHash("IsWalk");
        private static readonly int IsJumpAnimation = Animator.StringToHash("IsJump");
        private static readonly int IsFallAnimation = Animator.StringToHash("IsFall");

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void StartWalking() =>
            _animator.SetBool(IsWalkAnimation, true);

        public void StopWalking() =>
            _animator.SetBool(IsWalkAnimation, false);

        public void StartJumping() =>
            _animator.SetBool(IsJumpAnimation, true);

        public void StopJumping() =>
            _animator.SetBool(IsJumpAnimation, false);

        public void StartFalling() =>
            _animator.SetBool(IsFallAnimation, true);

        public void StopFalling() =>
            _animator.SetBool(IsFallAnimation, false);
    }
}