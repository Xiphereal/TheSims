namespace Domain
{
    public class Sim
    {
        public int Hunger { get; set; }

        public void Eat(Food food)
        {
            Hunger += food.Repletion;
        }
    }
}