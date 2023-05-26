namespace Domain
{
    public class Sim
    {
        private int hunger;

        public int Hunger
        {
            get => hunger;
            private set
            {
                hunger = value > 100 ? 100 : value;
            }
        }

        public Sim(int hunger)
        {
            Hunger = hunger;
        }

        public void Eat(Food food)
        {
            Hunger += food.Repletion;
        }
    }
}