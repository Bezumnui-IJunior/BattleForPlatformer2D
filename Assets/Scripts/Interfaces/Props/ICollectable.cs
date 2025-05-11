namespace Props
{
    public interface ICollectable
    {
        public void Accept(ICollector collector);
    }
}