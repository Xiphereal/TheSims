﻿namespace Domain.Tests.Builders
{
    internal class SimBuilder
    {
        private int hunger = 100;
        private int hygiene = 100;

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

        public Sim Build()
        {
            return new Sim(hunger, hygiene);
        }
    }
}