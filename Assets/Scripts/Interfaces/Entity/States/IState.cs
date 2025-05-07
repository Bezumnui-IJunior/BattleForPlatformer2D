using System;

namespace Entity.States
{
    public interface IState
    {
        public event Action OnExited;
        public void Occupy();
        public void Update();
    }
}