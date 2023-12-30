using Domain.Actions;
using Domain.Extensions;
using Domain.Needings;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Domain
{
    public delegate void ActionPerformed(Action performed);

    public class Sim
    {
        private const int ArbitraryValueThatShouldDependOnTheInteractableQuality = 5;
        private Queue<Action> actions = new();
        private System.TimeSpan currentActionElapsedTime;

        public int Hunger => Needs.Hunger;
        public int Hygiene => Needs.Hygiene;
        public int Bladder => Needs.Bladder;
        public int Energy => Needs.Energy;
        public int Comfort => Needs.Comfort;
        public Needs Needs { get; }

        public Vector3 Position { get; set; }

        public Vector3 TargetDestination =>
            actions.Any()
                ? actions.Peek().InteractablePosition
                : Position;

        public event ActionPerformed ActionPerformed;

        public event System.EventHandler Moved;

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
            action.ContinuePerforming(performer: this);

            ActionPerformed?.Invoke(performed: action);
        }

        public void Eat(Food food)
        {
            // Esto en algún momento fallará y no sabré por qué.
            Needs.Hunger += food.Repletion;
        }

        public void IncreaseNeeds()
        {
            Needs.Increase();
        }

        public void Sleep()
        {
            Needs.Energy += ArbitraryValueThatShouldDependOnTheInteractableQuality;
            RestoreComfort();
        }

        public void RestoreHygiene()
        {
            Needs.Hygiene += ArbitraryValueThatShouldDependOnTheInteractableQuality;
        }

        public void RestoreBladder()
        {
            Needs.Bladder += ArbitraryValueThatShouldDependOnTheInteractableQuality;
        }

        public void RestoreComfort()
        {
            Needs.Comfort += ArbitraryValueThatShouldDependOnTheInteractableQuality;
        }

        public void ContinuePerformingActionAtHand(int during = 1)
        {
            if (!actions.Any())
                return;

            currentActionElapsedTime += System.TimeSpan.FromSeconds(during);

            if (!NearToInteractable())
                return;

            for (int i = 0; i < during; i++)
                actions.Peek().ContinuePerforming(this);

            if (actions.Peek().Duration <= currentActionElapsedTime)
            {
                Action performed = actions.Dequeue();
                ActionPerformed?.Invoke(performed);

                currentActionElapsedTime = System.TimeSpan.Zero;
            }
        }
    }
}