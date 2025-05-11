namespace Props
{
    public interface ICollector
    {
        public void Collect(Coin coin);
        public void Collect(Medkit medkit);
    }
}