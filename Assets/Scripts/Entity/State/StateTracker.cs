using System.Collections.Generic;
using Entity.IState;
using Move;
using UnityEngine;

namespace Entity.State
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class StateTracker : MonoBehaviour, IStateTracker
    {
        [SerializeField] private FallingTracker _fallingTracker = new();
        [SerializeField] private JumpingTracker _jumpingTracker = new();
        [SerializeField] private WalkingTracker _walkingTracker = new();
        [SerializeField] private GroundedTracker _groundedTracker = new();

        private List<Tracker> _trackers;

        public IFallingTracker FallingTracker => _fallingTracker;
        public IJumpingTracker JumpingTracker => _jumpingTracker;
        public IWalkingTracker WalkingTracker => _walkingTracker;
        public IGroundedTracker GroundedTracker => _groundedTracker;

        private void Awake()
        {
            Rigidbody2D rigidbodyComponent = GetComponent<Rigidbody2D>();
            IMove move = GetComponent<IMove>();
            GroundChecker groundChecker = GetComponent<GroundChecker>();

            _fallingTracker.Init(rigidbodyComponent);
            _jumpingTracker.Init(this, move);
            _walkingTracker.Init(rigidbodyComponent, move);
            _groundedTracker.Init(groundChecker);

            Tracker[] trackers =
            {
                _fallingTracker,
                _jumpingTracker,
                _walkingTracker,
                _groundedTracker
            };

            _trackers = new List<Tracker>(trackers);
        }

        private void OnEnable()
        {
            foreach (Tracker tracker in _trackers)
                tracker.OnEnable();
        }

        private void Update()
        {
            foreach (Tracker tracker in _trackers)
                tracker.Update();
        }

        private void OnDisable()
        {
            foreach (Tracker tracker in _trackers)
                tracker.OnDisable();
        }
    }
}