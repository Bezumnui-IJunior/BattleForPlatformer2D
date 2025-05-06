using System;
using Entity.Trackers;
using UnityEngine;

namespace Entity
{
    [RequireComponent(typeof(IMover))]
    [RequireComponent(typeof(IRotator))]
    [RequireComponent(typeof(IEntityAnimator))]
    [RequireComponent(typeof(IStateTracker))]
    public class Entity : MonoBehaviour, IDieProvider
    {
        public IRotator Rotator { get; private set; }
        public EntityMotion Motion { get; private set; }

        private void Awake()
        {
            IEntityAnimator animator = GetComponent<IEntityAnimator>();
            IStateTracker tracker = GetComponent<IStateTracker>();
            IMover mover = GetComponent<IMover>();

            Rotator = GetComponent<IRotator>();

            tracker.Initialize();

            Motion = new EntityMotion(mover, Rotator, animator, tracker);
        }

        private void OnEnable() =>
            Motion.OnEnable();

        private void OnDisable() =>
            Motion.OnDisable();

        public void Die() =>
            Destroy(gameObject);
    }
}