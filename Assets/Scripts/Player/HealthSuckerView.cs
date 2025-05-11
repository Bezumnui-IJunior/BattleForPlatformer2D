using UnityEngine;

namespace Player
{
    public class HealthSuckerView : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private SuckerField _suckerFieldPrefab;

        private SuckerField _suckerField;

        private void Awake()
        {
            _suckerField = Instantiate(_suckerFieldPrefab, transform);
            _suckerField.Disable();
        }

        private void OnEnable()
        {
            _player.PlayerTracker.Suck.Sucking += _suckerField.Enable;
            _player.PlayerTracker.Suck.SuckStopped += _suckerField.Disable;
        }

        private void OnDisable()
        {
            _player.PlayerTracker.Suck.Sucking -= _suckerField.Enable;
            _player.PlayerTracker.Suck.SuckStopped -= _suckerField.Disable;
        }
    }
}