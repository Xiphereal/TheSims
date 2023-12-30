namespace Domain.Needings
{
    internal abstract class Need
    {
        private readonly int current;

        public Need(int current)
        {
            this.current = current;
        }

        public abstract int Increment { get; }

        internal int Increase()
        {
            return current - Increment;
        }
    }
}