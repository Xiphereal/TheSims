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

        public Sim(int hunger, int hygiene, int energy)
        {
            Hunger = hunger;
            Hygiene = hygiene;
            Energy = energy;
        }

        public void Eat(Food food)
        {
            Hunger += food.Repletion;
        }

        public void Use(IUsable usable)
        {
            usable.Use(user: this);
        }

        public void Sleep()
        {
            Energy = 100;
        }

        public void RestoreHygiene()
        {
            Hygiene = 100;
        }
    }
}