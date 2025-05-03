using System;

namespace Entity.IState
{
    public interface IFallingTracker
    {
        event Action FallingStarting;
        event Action FallingStopped;
    }
}