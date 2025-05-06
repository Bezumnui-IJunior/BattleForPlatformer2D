namespace Props
{
    public interface ICollector
    {
        public bool TryCollect(ICollectable collectable);
    }
}