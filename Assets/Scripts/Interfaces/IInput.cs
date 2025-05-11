using System;

public interface IInput
{
    public event Action Jumping;
    public event Action Attacking;
    public event Action Sucking;

    public float HorizontalSpeed { get; }
}