namespace Domain.Need
{
    internal class Hygiene
    {
        private const int Increment = 2;
        private readonly int current;

        public Hygiene(int hygiene)
        {
            current = hygiene;
        }

        internal int Increase()
        {
            return current - Increment;
        }
    }
}