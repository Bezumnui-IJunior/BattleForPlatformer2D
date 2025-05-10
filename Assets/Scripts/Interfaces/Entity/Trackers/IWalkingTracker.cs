using System;

namespace Entity.Trackers
{
    public interface IWalkingTracker
    {
        event Action WalkingStopped;

        public bool TryStartWalk();
    }
}