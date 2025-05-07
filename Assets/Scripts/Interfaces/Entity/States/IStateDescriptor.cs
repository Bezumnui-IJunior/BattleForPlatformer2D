namespace Entity.States
{
    public interface IStateDescriptor
    {
        public void ChangeState<T>() where T : State;
    }
}