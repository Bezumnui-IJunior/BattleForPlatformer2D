using UnityEngine;

namespace Entity
{
    public interface ISuckable
    {
        public Transform Transform { get; }

        public float Damage(float maxHealth);
    }
}