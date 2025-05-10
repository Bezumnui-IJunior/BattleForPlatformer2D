using System;

namespace Enemy.Trackers
{
    public interface IAttackTracker
    {
        event Action AttackAllowed;
        bool CanAttack { get; }
        void Attack();
    }
}