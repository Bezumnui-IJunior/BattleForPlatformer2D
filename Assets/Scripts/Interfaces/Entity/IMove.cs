using System;

namespace Move
{
    public interface IMove
    {
        event Action StartWalking;
        event Action StartJumping;
        event Action StopWalking;
    }
}