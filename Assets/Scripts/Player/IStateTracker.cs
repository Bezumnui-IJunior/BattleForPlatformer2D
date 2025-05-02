using System;

namespace Player
{
    public interface IStateTracker
    {
        event Action StartFalling;
        event Action StopFalling;
        event Action StartJumping;
        event Action StopJumping;
        event Action StartWalking;
        event Action StopWalking;
    }
}