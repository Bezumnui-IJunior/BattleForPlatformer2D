using System;
using UnityEngine;

namespace Entity.Trackers
{
    public class ColliderTracker : IColliderTracker
    {
        public event Action<Collider2D> OnTriggerEnter;
        public event Action<Collider2D> OnTriggerExit;

        public void TriggerEnter2D(Collider2D other) =>
            OnTriggerEnter?.Invoke(other);

        public void TriggerExit2D(Collider2D other) =>
            OnTriggerExit?.Invoke(other);
    }
}