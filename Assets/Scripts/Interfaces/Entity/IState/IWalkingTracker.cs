using System;

namespace Entity.IState
{
    public interface IWalkingTracker
    {
        event Action WalkingStopped;

        public bool TryStartWalk();
    }
}