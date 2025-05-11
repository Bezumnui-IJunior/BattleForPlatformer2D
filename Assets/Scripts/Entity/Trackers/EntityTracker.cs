using System.Collections.Generic;
using Entity.StaticData;
using Physics;
using UnityEngine;

namespace Entity.Trackers
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(IGroundChecker))]
    public class EntityTracker : MonoBehaviour, IEntityTracker, ICoroutineExecutor
    {
        [SerializeField] private TrackerData _trackerData;

        private FallingTracker _fall;
        private JumpingTracker _jump;
        private WalkingTracker _walk;
        private GroundedTracker _ground;
        private ColliderTracker _colliderTracker;

        private List<Tracker> _trackers;

        public IFallingTracker Fall => _fall;
        public IJumpingTracker Jump => _jump;
        public IWalkingTracker Walk => _walk;
        public IGroundedTracker Ground => _ground;

        public void Initialize()
        {
            Rigidbody2D rigidbodyComponent = GetComponent<Rigidbody2D>();
            IGroundChecker groundChecker = GetComponent<IGroundChecker>();

            _fall = new FallingTracker(rigidbodyComponent, _trackerData.FallThreshold);
            _jump = new JumpingTracker(this, _trackerData.JumpCooldown);
            _walk = new WalkingTracker(rigidbodyComponent);
            _ground = new GroundedTracker(groundChecker);
            _colliderTracker = new ColliderTracker();

            Tracker[] trackers =
            {
                _fall,
                _jump,
                _walk,
                _ground,
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