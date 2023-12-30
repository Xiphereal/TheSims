namespace Domain.Need
{
    internal class Bladder
    {
        private const int Increment = 3;
        private readonly int current;

        public Bladder(int bladder)
        {
            current = bladder;
        }

        internal int Increase()
        {
            return current - Increment;
        }
    }
}