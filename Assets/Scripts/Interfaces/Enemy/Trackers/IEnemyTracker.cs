namespace Enemy.Trackers
{
    public interface IEnemyTracker
    {
        IAttackTracker Attack { get; }
        IMovementTracker Movement { get; }
    }
}