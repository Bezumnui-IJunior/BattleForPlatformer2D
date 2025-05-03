using System;

namespace Entity.IState
{
    public interface IFallingTracker
    {
        event Action StartFalling;
        event Action StopFalling;
    }
}