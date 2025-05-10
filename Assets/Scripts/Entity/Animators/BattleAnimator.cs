using UnityEngine;

namespace Entity.Animators
{
    public class BattleAnimator : IBattleAnimator
    {
        private readonly int _attackAnimation = Animator.StringToHash("Attack");

        private readonly Animator _animator;

        public BattleAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void Attack() =>
            _animator.SetTrigger(_attackAnimation);
    }
}