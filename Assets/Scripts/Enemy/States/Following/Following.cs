using System;
using Entity.States;

namespace Enemy.States.Following
{
    public class Following : IState
    {
        public event Action OnExited;
        
        public void Occupy()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}