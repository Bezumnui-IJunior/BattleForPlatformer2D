using Attributes;
using Misc;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    public abstract class Bar : MonoBehaviour, IToggle
    {
        [SerializeField, Restrict(typeof(IChangeableValue))]
        private Object _changeable;

        protected Slider Slider { get; private set; }

        protected IChangeableValue Changeable => _changeable as IChangeableValue;

        protected virtual void Awake()
        {
            Slider = GetComponent<Slider>();
        }

        private void OnEnable()
        {
            Changeable.Decreased += OnDecreased;
            Changeable.Increased += OnIncreased;
            Changeable.Initiated += OnInitiated;
            OnInitiated();
        }

        private void OnDisable()
        {
            Changeable.Decreased -= OnDecreased;
            Changeable.Increased -= OnIncreased;
            Changeable.Initiated -= OnInitiated;
        }

        private void OnInitiated()
        {
            Slider.minValue = Changeable.MinValue;
            Slider.maxValue = Changeable.MaxValue;
            Slider.value = Changeable.Value;
        }

        protected abstract void OnDecreased();
        protected abstract void OnIncreased();

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}