namespace Entity.Trackers
{
    public interface IEntityTracker
    {
        public IFallingTracker Fall { get; }
        public IJumpingTracker Jump { get; }
        public IWalkingTracker Walk { get; }
        public IGroundedTracker Ground { get; }

        public void Initialize();
    }
}