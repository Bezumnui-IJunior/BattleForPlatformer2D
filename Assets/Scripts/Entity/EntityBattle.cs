using Entity.Animators;
using UnityEngine;

namespace Entity
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(IAttacker))]
    public class EntityBattle : MonoBehaviour, IEntityBattle
    {
        private IBattleAnimator _animator;
        private IAttacker _attacker;

        private void Awake()
        {
            _animator = new BattleAnimator(GetComponent<Animator>());
            _attacker = GetComponent<IAttacker>();
        }

        public void Attack()
        {
            _attacker.Attack();
            _animator.Attack();
        }
    }
}