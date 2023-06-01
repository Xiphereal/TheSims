using Domain.Actions;
using Domain.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Sim
    {
        private Queue<IAction> actions = new();

        public int Hunger => Needs.Hunger;
        public int Hygiene => Needs.Hygiene;
        public int Bladder => Needs.Bladder;
        public int Energy => Needs.Energy;
        public int Comfort => Needs.Comfort;
        public Needs Needs { get; }

        public Sim(Needs needs)
        {
            Needs = needs;
        }

        public void Command(IAction action)
        {
            actions.Enqueue(action);
        }

        public void Cancel(IAction action)
        {
            actions = actions.Without(action);
        }

        public void PerformNextAction()
        {
            if (actions.Any())
                Perform(actions.Dequeue());
        }

        public void Perform(IAction action)
        {
            action.Perform(performer: this);
        }

        public void Eat(Food food)
        {
            Needs.Hunger += food.Repletion;
        }

        public void IncreaseNeeds()
        {
            Needs.Increase();
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

        public void RestoreBladder()
        {
            Needs.Bladder = 100;
        }

        public void RestoreComfort()
        {
            Needs.Comfort = 100;
        }
    }
}