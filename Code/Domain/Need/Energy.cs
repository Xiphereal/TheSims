namespace Domain.Need
{
    internal class Energy
    {
        private const int Increment = 1;
        private readonly int current;

        public Energy(int energy)
        {
            current = energy;
        }

        internal int Increase()
        {
            return current - Increment;
        }
    }
}