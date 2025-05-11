using System;

namespace UI.View
{
    public interface IChangeableValue
    {
        float Value { get; }
        public float MaxValue { get; }
        public float MinValue { get; }

        event Action Decreased;
        event Action Increased;
        event Action Initiated;
    }
}