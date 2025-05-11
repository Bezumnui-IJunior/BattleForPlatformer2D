using UI.View;
using UnityEngine;

namespace Entity
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private EntityHealth _health;
        [SerializeField] private Bar _bar;

        private bool _isShow;

        private void OnEnable()
        {
            _health.Initiated += OnInitialized;
            _health.Decreased += OnDecreased;
        }

        private void OnDisable()
        {
            _health.Initiated -= OnInitialized;
            _health.Decreased -= OnDecreased;
        }

        private void OnInitialized()
        {
            if (Mathf.Approximately(_health.Value, _health.MaxValue))
            {
                _isShow = false;
                // _bar.Disable();
            }
            else
            {
                _isShow = true;
                _bar.Enable();
            }
        }

        private void OnDecreased()
        {
            if (_isShow)
                return;

            _isShow = true;
            _bar.Enable();
        }
    }
}