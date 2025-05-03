using System;

namespace Entity
{
    public interface IStateTracker
    {
        event Action StartFalling;
        event Action StopFalling;
        event Action StartJumping;
        event Action StopJumping;
        event Action<float> StartWalking;
        event Action StopWalking;
    }
}