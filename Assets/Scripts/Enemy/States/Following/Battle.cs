using Misc;

namespace Enemy.States.Following
{
    public class Battle : IToggle
    {
        private readonly Enemy _enemy;

        private readonly ICoroutineExecutor _executor;
        private readonly CooldownTimer _timer;

        public Battle(Enemy enemy, CooldownTimer timer)
        {
            _enemy = enemy;
            _timer = timer;
        }

        public void Enable()
        {
            _enemy.EnemyTracker.AttackTracker.AttackAllowed += _timer.Start;
            _timer.Freed += Attack;
        }

        public void Disable()
        {
            _enemy.EnemyTracker.AttackTracker.AttackAllowed -= _timer.Start;
            _timer.Freed -= Attack;
        }

        private void Attack()
        {
            if (_enemy.AttackField.IsContainTarget)
                _enemy.EntityBattle.Attack();
        }
    }
}