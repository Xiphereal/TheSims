using Domain.Actions;

namespace Domain
{
    public class Sim
    {
        public int Hunger => Needs.Hunger;
        public int Hygiene => Needs.Hygiene;
        public int Energy => Needs.Energy;
        public int Comfort => Needs.Comfort;
        public Needs Needs { get; }

        public Sim(Needs needs)
        {
            Needs = needs;
        }

        public void Eat(Food food)
        {
            Needs.Hunger += food.Repletion;
        }

        public void Perform(IAction action)
        {
            action.Perform(performer: this);
        }

        public void Sleep()
        {
            Needs.Energy = 100;
            RestoreComfort();
        }

        public void RestoreHygiene()
        {
            Needs.Hygiene = 100;
        }

        public void RestoreComfort()
        {
            Needs.Comfort = 100;
        }
    }
}