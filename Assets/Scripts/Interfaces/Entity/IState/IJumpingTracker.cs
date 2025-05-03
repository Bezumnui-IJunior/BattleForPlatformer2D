using System;

namespace Entity.IState
{
    public interface IJumpingTracker
    {
        public bool CanJump();
        public void Jump();

        public event Action JumpingStopped;
    }
}