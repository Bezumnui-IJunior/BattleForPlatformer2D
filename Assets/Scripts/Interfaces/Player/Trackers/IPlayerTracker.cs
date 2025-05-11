using UnityEngine;

namespace Player.Trackers
{
    public interface IPlayerTracker
    {
        ISuckTracker Suck { get; }
    }
}