using System;

public interface IInput
{
    public event Action Jumping;

    public float HorizontalSpeed { get; }
}