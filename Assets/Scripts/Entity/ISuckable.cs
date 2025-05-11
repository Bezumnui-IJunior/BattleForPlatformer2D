
using UnityEngine;

namespace Entity
{
    public interface ISuckable
    {
        public Transform Transform { get; }

        public float TakeHealth(float maxHealth);
    }
}