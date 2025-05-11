using System;

namespace Enemy
{
    public interface IAttackField
    {
        public bool IsContainTarget { get; }
        event Action TargetEntered;
    }
}