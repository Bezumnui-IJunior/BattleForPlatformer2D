using System;

namespace Entity.IState
{
    public interface IWalkingTracker
    {
        event Action<float> StartWalking;
        event Action StopWalking;
    }
}