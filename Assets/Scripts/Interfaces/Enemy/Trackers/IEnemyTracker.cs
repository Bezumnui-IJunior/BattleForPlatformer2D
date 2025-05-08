namespace Enemy.Trackers
{
    public interface IEnemyTracker
    {
        IAttackTracker AttackTracker { get; }
    }
}