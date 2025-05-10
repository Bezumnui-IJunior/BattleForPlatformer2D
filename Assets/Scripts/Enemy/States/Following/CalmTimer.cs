using Enemy.States.Patrolling;
using Entity.States;
using Misc;

namespace Enemy.States.Following
{
    public class CalmTimer : IToggle
    {
        private readonly CooldownTimer _timer;
        private readonly IStateMachine _stateMachine;

        public CalmTimer(CooldownTimer timer, IStateMachine stateMachine)
        {
            _timer = timer;
            _stateMachine = stateMachine;
        }

        public void Enable()
        {
            _timer.Freed += OnCalmTimer;
            _timer.Start();
        }

        public void Disable()
        {
            _timer.Freed -= OnCalmTimer;
        }

        public void Restart()
        {
            _timer.Restart();
        }

        private void OnCalmTimer()
        {
            _stateMachine.ChangeState<PatrollingState>();
        }
    }
}