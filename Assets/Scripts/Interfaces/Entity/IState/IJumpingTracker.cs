using System;

namespace Entity.IState
{
    public interface IJumpingTracker
    {
        event Action StartJumping;
        event Action StopJumping;
    }
}