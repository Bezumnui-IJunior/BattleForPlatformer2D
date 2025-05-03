using System;

public interface IInput
{
    public event Action GoingLeft;
    public event Action GoingRight;
    public event Action HorizontalStopping;
    
    public event Action Jumping;
}