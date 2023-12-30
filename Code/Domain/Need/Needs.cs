using System;

namespace Domain.Need
{
    public class Needs
    {
        private const int NeedMinValue = 0;
        private const int NeedMaxValue = 100;

        private int hunger;

        public int Hunger
        {
            get => hunger;
            set
            {
                hunger = Math.Clamp(value, NeedMinValue, NeedMaxValue);
            }
        }

        private int hygiene;
        public int Hygiene { get => hygiene; set => hygiene = Math.Clamp(value, NeedMinValue, NeedMaxValue); }

        private int bladder;
        public int Bladder { get => bladder; set => bladder = Math.Clamp(value, NeedMinValue, NeedMaxValue); }

        private int energy;
        public int Energy { get => energy; set => energy = Math.Clamp(value, NeedMinValue, NeedMaxValue); }

        private int comfort;
        public int Comfort { get => comfort; set => comfort = Math.Clamp(value, NeedMinValue, NeedMaxValue); }

        public Needs(int hunger, int hygiene, int bladder, int energy, int confort)
        {
            Hunger = hunger;
            Hygiene = hygiene;
            Bladder = bladder;
            Energy = energy;
            Comfort = confort;
        }

        public void Increase()
        {
            Hunger = new Hunger(hunger).Increase();
            Hygiene = new Hygiene(hygiene).Increase();
            Bladder = new Bladder(bladder).Increase();
            Energy = new Energy(energy).Increase();
            Comfort = new Comfort(comfort).Increase();
        }
    }
}