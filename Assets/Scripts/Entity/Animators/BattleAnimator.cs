using UnityEngine;

namespace Entity.Animators
{
    public class BattleAnimator : IBattleAnimator
    {
        private readonly Animator _animator;
        private readonly int _attackAnimation = Animator.StringToHash("Attack");

        public BattleAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void Attack()
        {
            _animator.SetTrigger(_attackAnimation);
        }
    }
}