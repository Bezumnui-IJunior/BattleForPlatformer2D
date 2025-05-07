using System;
using Entity.States;

namespace Enemy.States.Patrolling
{
    public class Patrolling : IState
    {
        private PatrollingMovement _movement;
        
        public event Action OnExited;
        
        public void Occupy()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        private void Exit()
        {
            OnExited?.Invoke();
        }
    }
}