using System;
using Entity.IState;
using Move;
using Player;
using UnityEngine;

namespace Entity
{
    [RequireComponent(typeof(IMover))]
    [RequireComponent(typeof(IRotator))]
    [RequireComponent(typeof(IEntityAnimator))]
    [RequireComponent(typeof(IStateTracker))]
    public class Entity : MonoBehaviour
    {
        public IRotator Rotator { get; private set; }
        public IMover Move { get; private set; }
        public EntityMotion Motion { get; private set; }

        private void Awake()
        {
            IEntityAnimator animator = GetComponent<IEntityAnimator>();
            IStateTracker tracker = GetComponent<IStateTracker>();
            Rotator = GetComponent<IRotator>();
            Move = GetComponent<IMover>();

            tracker.Initialize();

            Motion = new EntityMotion(Move, Rotator, animator, tracker);
        }

        private void OnEnable() =>
            Motion.OnEnable();

        private void OnDisable() =>
            Motion.OnDisable();
    }
}