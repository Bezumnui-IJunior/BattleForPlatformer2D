using System;
using System.Collections.Generic;
using Entity.StaticData;
using Physics;
using UnityEngine;

namespace Entity.Trackers
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(IGroundChecker))]
    public class StateTracker : MonoBehaviour, IStateTracker, ICoroutineExecutor
    {
        [SerializeField] private TrackerData _trackerData;

        private FallingTracker _fallingTracker;
        private JumpingTracker _jumpingTracker;
        private WalkingTracker _walkingTracker;
        private GroundedTracker _groundedTracker;
        private ColliderTracker _colliderTracker;

        private List<Tracker> _trackers;

        public IFallingTracker FallingTracker => _fallingTracker;
        public IJumpingTracker JumpingTracker => _jumpingTracker;
        public IWalkingTracker WalkingTracker => _walkingTracker;
        public IGroundedTracker GroundedTracker => _groundedTracker;
        public IColliderTracker ColliderTracker => _colliderTracker;

        public void Initialize()
        {
            Rigidbody2D rigidbodyComponent = GetComponent<Rigidbody2D>();
            IGroundChecker groundChecker = GetComponent<IGroundChecker>();

            _fallingTracker = new FallingTracker(rigidbodyComponent, _trackerData.FallThreshold);
            _jumpingTracker = new JumpingTracker(this, _trackerData.JumpCooldown);
            _walkingTracker = new WalkingTracker(rigidbodyComponent);
            _groundedTracker = new GroundedTracker(groundChecker);
            _colliderTracker = new ColliderTracker();

            Tracker[] trackers =
            {
                _fallingTracker,
                _jumpingTracker,
                _walkingTracker,
                _groundedTracker,
            };

            _trackers = new List<Tracker>(trackers);
        }

        private void Update()
        {
            foreach (Tracker tracker in _trackers)
                tracker.Update();
        }

        private void OnTriggerEnter2D(Collider2D other) =>
            _colliderTracker.TriggerEnter2D(other);

        private void OnTriggerExit2D(Collider2D other) =>
            _colliderTracker.TriggerExit2D(other);
    }
}