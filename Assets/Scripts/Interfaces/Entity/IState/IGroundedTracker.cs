using System;

namespace Entity.IState
{
    public interface IGroundedTracker
    {
        event Action Grounded;
        public bool IsGround { get; }
    }
}