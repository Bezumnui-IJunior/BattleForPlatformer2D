namespace Entity.States
{
    public interface IStateMachine
    {
        public void ChangeState<T>() where T : State;
    }
}