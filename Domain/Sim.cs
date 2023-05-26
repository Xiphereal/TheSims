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

        public Sim(int hunger, int hygiene)
        {
            Hunger = hunger;
            Hygiene = hygiene;
        }

        public void Eat(Food food)
        {
            Hunger += food.Repletion;
        }

        public void Use(Shower shower)
        {
            Hygiene = NeedMaxValue;
        }
    }
}