using System;

namespace Player.Trackers
{
    public interface ISuckTracker
    {
        bool CanSuck { get; }
        event Action Sucking;
        event Action SuckStopped;
        void StartSuck();
    }
}