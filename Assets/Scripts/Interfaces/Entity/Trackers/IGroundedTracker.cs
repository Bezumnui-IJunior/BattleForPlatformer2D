using System;

namespace Entity.Trackers
{
    public interface IGroundedTracker
    {
        event Action Grounded;
        public bool IsGround { get; }
    }
}