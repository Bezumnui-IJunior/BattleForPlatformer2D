using System;

namespace Entity.Trackers
{
    public interface IFallingTracker
    {
        event Action FallingStarting;
        event Action FallingStopped;
    }
}