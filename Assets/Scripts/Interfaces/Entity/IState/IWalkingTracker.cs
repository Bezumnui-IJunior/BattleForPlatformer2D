using System;

namespace Entity.IState
{
    public interface IWalkingTracker
    {
        event Action WalkingStoped;

        public bool TryStartWalk();
    }
}