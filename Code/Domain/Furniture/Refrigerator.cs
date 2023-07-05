using Domain.Actions;
using System.Collections.Generic;

namespace Domain.Furniture
{
    public class Refrigerator : IInteractable
    {
        public Refrigerator(int hunger)
        {
            Food = new Food(repletion: hunger);
        }

        public Food Food { get; }

        public IEnumerable<Action> AvailableActions() => new List<Action> { new Eat(from: this) };
    }
}