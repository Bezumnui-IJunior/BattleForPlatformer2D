using System;

public interface IInput
{
    public float HorizontalSpeed { get; }
    public event Action Jumping;
    public event Action Attacking;
    public event Action Sucking;
}