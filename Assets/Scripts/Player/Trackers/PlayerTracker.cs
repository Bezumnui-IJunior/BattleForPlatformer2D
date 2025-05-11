using UnityEngine;

namespace Player.Trackers
{
    public class PlayerTracker : MonoBehaviour, IPlayerTracker, ICoroutineExecutor
    {
        [SerializeField] private float _suckSeconds = 6;
        [SerializeField] private float _suckCooldownSeconds = 4;
        [SerializeField] private int _suckCount = 4;

        private SuckTracker _suck;

        public ISuckTracker Suck => _suck;

        private void OnEnable()
        {
            _suck.Enable();
        }

        private void OnDisable()
        {
            _suck.Disable();
        }

        public void Initialize()
        {
            _suck = new SuckTracker(this, _suckCount, _suckCooldownSeconds, _suckSeconds);
        }
    }
}