using System;

public interface IInput
{
    public event Action Jumping;
    public event Action Attacking;

    public float HorizontalSpeed { get; }
}