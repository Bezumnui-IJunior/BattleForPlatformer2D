using UnityEngine;

namespace Entity
{
    public interface IAttacker
    {
        public float Damage { get; }
        public Transform Transform { get; }
        public void Attack();
    }
}