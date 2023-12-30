﻿namespace Domain.Needings
{
    internal class Hunger : Need
    {
        public Hunger(int hunger) : base(hunger)
        {
        }

        public override int Increment => 5;
    }
}