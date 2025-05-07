using Entity.Animators;
using Physics;
using Player;
using UnityEngine;

namespace Entity
{
    [RequireComponent(typeof(Animator))]
    public class EntityAttack : MonoBehaviour, IEntityAttack
    {
        [SerializeField] private BoxColliderDetector _detector;

        private IAttacker _attacker;
        private IBattleAnimator _animator;

        private void Awake()
        {
            _animator = new BattleAnimator(GetComponent<Animator>());
            _attacker = new Attacker(_detector, transform);
        }

        public void Attack()
        {
            _attacker.Attack();
            _animator.Attack();
        }
    }
}