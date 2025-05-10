using UnityEngine;

namespace Entity
{
    public interface IAttacker
    {
        public Transform Transform { get; }
        public void Attack();
    }
}