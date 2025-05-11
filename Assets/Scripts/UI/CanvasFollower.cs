using System;
using UnityEngine;

namespace UI
{
    public class CanvasFollower : MonoBehaviour
    {
        [SerializeField] private FollowerPlaceholder _target;

        private Camera _camera;
        private RectTransform RectTransform => (RectTransform)transform;

        private void Awake()
        {
            _camera = Camera.main;

            if (_camera == null)
                throw new NullReferenceException("Camera is null");
        }

        private void Update()
        {
            RectTransform.position = _camera.WorldToScreenPoint(_target.transform.position);
        }
    }
}