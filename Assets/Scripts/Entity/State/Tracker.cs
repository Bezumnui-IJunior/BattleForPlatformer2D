namespace Entity.State
{
    public abstract class Tracker
    {
        public abstract void Update();

        public virtual void OnEnable() { }

        public virtual void OnDisable() { }
    }
}