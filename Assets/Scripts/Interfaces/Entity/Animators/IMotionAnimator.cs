namespace Entity.Animators
{
    public interface IMotionAnimator
    {
        public void StartWalking();
        public void StopWalking();
        public void StartJumping();
        public void StopJumping();
        public void StartFalling();
        public void StopFalling();
    }
}