using System;

namespace Enemy
{
    public interface IAttackField
    {
        event Action TargetEntered;
        
        public bool IsContainTarget { get; }
    }
}