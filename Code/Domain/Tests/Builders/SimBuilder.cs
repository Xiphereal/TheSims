using Domain.Needss;
using System.Numerics;

namespace Domain.Tests.Builders
{
    public class SimBuilder
    {
        private int hunger = 100;
        private int hygiene = 100;
        private int bladder = 100;
        private int energy = 100;
        private int comfort = 100;

        private Vector3 position;

        private SimBuilder()
        { }

        public static SimBuilder Sim() => new();

        public static SimBuilder SimWithAllNeedsToMinimum() => new()
        {
            hunger = 0,
            hygiene = 0,
            bladder = 0,
            energy = 0,
            comfort = 0,
        };

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

        public SimBuilder WithBladder(int value)
        {
            bladder = value;

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

        public SimBuilder At(Vector3 position)
        {
            this.position = position;

            return this;
        }

        public Sim Build()
        {
            return new Sim(new Needs(hunger, hygiene, bladder, energy, comfort))
            {
                Position = position
            };
        }
    }
}