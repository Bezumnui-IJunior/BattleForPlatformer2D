using System;
using UnityEngine;

namespace Entity.Trackers
{
    public interface IColliderTracker
    {
        public event Action<Collider2D> OnTriggerEnter;
        public event Action<Collider2D> OnTriggerExit;
    }
}