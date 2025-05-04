using System;

public interface IInput
{
    public float HorizontalSpeed { get; }
    public event Action Jumping;
}