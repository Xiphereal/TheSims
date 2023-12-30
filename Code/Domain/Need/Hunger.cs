namespace Domain.Need
{
    internal class Hunger
    {
        private const int Increment = 5;
        private readonly int current;

        public Hunger(int hunger)
        {
            current = hunger;
        }

        internal int Increase()
        {
            return current - Increment;
        }
    }
}