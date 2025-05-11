using Entity.Animators;
using Entity.Trackers;
using UnityEngine;

namespace Entity
{
    [RequireComponent(typeof(IMover))]
    [RequireComponent(typeof(IRotator))]
    [RequireComponent(typeof(IEntityTracker))]
    public class Entity : MonoBehaviour
    {
        public IRotator Rotator { get; private set; }
        public EntityMotion Motion { get; private set; }
        public IEntityTracker Tracker { get; private set; }

        private void Awake()
        {
            IMotionAnimator motionAnimator = new MotionAnimator(GetComponent<Animator>());
            Tracker = GetComponent<IEntityTracker>();
            IMover mover = GetComponent<IMover>();

            Rotator = GetComponent<IRotator>();

            Tracker.Initialize();

            Motion = new EntityMotion(mover, Rotator, motionAnimator, Tracker);
        }

        private void OnEnable()
        {
            Motion.OnEnable();
        }

        private void OnDisable()
        {
            Motion.OnDisable();
        }
    }
}