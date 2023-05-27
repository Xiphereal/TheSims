namespace Domain.Tests.Builders
{
    internal class SimBuilder
    {
        private int hunger = 100;
        private int hygiene = 100;
        private int energy = 100;
        private int comfort = 100;

        private SimBuilder()
        { }

        public static SimBuilder Sim() => new();

        public SimBuilder WithHunger(int value)
        {
            hunger = value;

            return this;
        }

        public SimBuilder WithHygiene(int value)
        {
            hygiene = value;

            return this;
        }

        public SimBuilder WithEnergy(int value)
        {
            energy = value;

            return this;
        }

        public SimBuilder WithComfort(int value)
        {
            comfort = value;

            return this;
        }

        public Sim Build()
        {
            return new Sim(new Needs(hunger, hygiene, energy, comfort));
        }
    }
}