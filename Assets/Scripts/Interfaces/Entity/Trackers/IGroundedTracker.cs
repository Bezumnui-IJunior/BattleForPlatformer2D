using System;

namespace Entity.Trackers
{
    public interface IGroundedTracker
    {
        public bool IsGround { get; }
        event Action Grounded;
    }
}