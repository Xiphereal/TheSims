using Domain.Actions;
using Domain.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Domain
{
    public delegate void Adsfkjadlsfj(Action performed);

    public class ActionPerformed : System.EventArgs
    {
        public ActionPerformed(Action performed)
        {
            Which = performed;
        }

        public Action Which { get; }
    }

    public class Sim
    {
        private Queue<Action> actions = new();

        public int Hunger => Needs.Hunger;
        public int Hygiene => Needs.Hygiene;
        public int Bladder => Needs.Bladder;
        public int Energy => Needs.Energy;
        public int Comfort => Needs.Comfort;
        public Needs Needs { get; }

        public Vector3 Position { get; set; }

        public event Adsfkjadlsfj ActionPerformed;

        public Sim(Needs needs)
        {
            Needs = needs;
        }

        public void Command(Action action)
        {
            actions.Enqueue(action);
        }

        public void Cancel(Action action)
        {
            actions = actions.Without(action);
        }

        public void PerformNextAction()
        {
            if (actions.Any() && NearToInteractable())
                Perform(actions.Dequeue());
        }

        private bool NearToInteractable()
        {
            if (actions.Peek() is MoveTo)
            {
                return true;
            }

            return Position == actions.Peek().InteractablePosition;
        }

        public void Perform(Action action)
        {
            action.Perform(performer: this);

            ActionPerformed?.Invoke(performed: action);
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