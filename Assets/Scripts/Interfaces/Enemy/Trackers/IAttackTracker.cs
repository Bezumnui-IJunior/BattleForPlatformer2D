using System;

namespace Enemy.Trackers
{
    public interface IAttackTracker
    {
        bool CanAttack { get; }
        event Action AttackAllowed;
        void Attack();
    }
}