using System;

namespace Entity.Trackers
{
    public interface IJumpingTracker
    {
        public bool CanJump();
        public void Jump();

        public event Action JumpingStopped;
    }
}