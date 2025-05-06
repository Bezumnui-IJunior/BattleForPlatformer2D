using System.Collections.Generic;
using Entity.IState;
using Entity.StaticDatas;
using Move;
using Physics;
using UnityEngine;

namespace Entity.Trackers
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(IGroundChecker))]
    public class StateTracker : MonoBehaviour, IStateTracker, ITimerUser
    {
        [SerializeField] private TrackerData _trackerData;

        private FallingTracker _fallingTracker;
        private JumpingTracker _jumpingTracker;
        private WalkingTracker _walkingTracker;
        private GroundedTracker _groundedTracker;

        private List<Tracker> _trackers;

        public IFallingTracker FallingTracker => _fallingTracker;
        public IJumpingTracker JumpingTracker => _jumpingTracker;
        public IWalkingTracker WalkingTracker => _walkingTracker;
        public IGroundedTracker GroundedTracker => _groundedTracker;

        public void Initialize()
        {
            Rigidbody2D rigidbodyComponent = GetComponent<Rigidbody2D>();
            IGroundChecker groundChecker = GetComponent<IGroundChecker>();

            _fallingTracker = new FallingTracker(rigidbodyComponent, _trackerData.FallThreshold);
            _jumpingTracker = new JumpingTracker(this, _trackerData.JumpCooldown);
            _walkingTracker = new WalkingTracker(rigidbodyComponent);
            _groundedTracker = new GroundedTracker(groundChecker);

            Tracker[] trackers =
            {
                _fallingTracker,
                _jumpingTracker,
                _walkingTracker,
                _groundedTracker
            };

            _trackers = new List<Tracker>(trackers);
        }

        private void Update()
        {
            foreach (Tracker tracker in _trackers)
                tracker.Update();
        }
    }
}