using UnityEngine;

namespace Player
{
    public class HealthSuckerView : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Field _fieldPrefab;

        private Field _field;

        private void OnEnable()
        {
            _player.PlayerTracker.Suck.Sucking += EnableField;
            _player.PlayerTracker.Suck.SuckStopped += DisableField;
        }

        private void OnDisable()
        {
            _player.PlayerTracker.Suck.Sucking -= EnableField;
            _player.PlayerTracker.Suck.SuckStopped -= DisableField;
        }

        private void EnableField()
        {
            if (_field != null)
                return;

            _field = Instantiate(_fieldPrefab, transform);
        }

        private void DisableField()
        {
            if (_field == null)
                return;

            _field.Destroy();
            _field = null;
        }
    }
}