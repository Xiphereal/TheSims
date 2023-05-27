using Domain.Actions;
using Domain.Furniture;

namespace Domain
{
    public class Sim
    {
        private const int NeedMaxValue = 100;
        private int hunger;

        public int Hunger
        {
            get => hunger;
            private set
            {
                hunger = value > NeedMaxValue ? NeedMaxValue : value;
            }
        }

        public int Hygiene { get; private set; }
        public int Energy { get; private set; }
        public int Comfort { get; set; }

        public Sim(int hunger, int hygiene, int energy, int confort)
        {
            Hunger = hunger;
            Hygiene = hygiene;
            Energy = energy;
            Comfort = confort;
        }

        public void Eat(Food food)
        {
            Hunger += food.Repletion;
        }

        public void Use(IUsable usable)
        {
            usable.Use(user: this);
        }

        public void Perform(IAction action)
        {
            action.Perform(performer: this);
        }

        public void Sleep()
        {
            Energy = 100;
        }

        public void RestoreHygiene()
        {
            Hygiene = 100;
        }

        public void RestoreComfort()
        {
            Comfort = 100;
        }
    }
}