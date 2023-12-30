namespace Domain.Need
{
    internal class Comfort
    {
        private const int Increment = 3;
        private readonly int current;

        public Comfort(int comfort)
        {
            current = comfort;
        }

        internal int Increase()
        {
            return current - Increment;
        }
    }
}