namespace Entity.Trackers
{
    public interface IStateTracker
    {
        public IFallingTracker FallingTracker { get; }
        public IJumpingTracker JumpingTracker { get; }
        public IWalkingTracker WalkingTracker { get; }
        public IGroundedTracker GroundedTracker { get; }

        public void Initialize();
    }
}