namespace Enemy.Trackers
{
    public class MovementTracker : IMovementTracker
    {
        private readonly Enemy _enemy;

        public MovementTracker(Enemy enemy)
        {
            _enemy = enemy;
        }

        public bool IsSafeToStep()
        {
            return _enemy.WallChecker.IsObstacle() == false && _enemy.VoidChecker.IsObstacle();
        }
    }
}