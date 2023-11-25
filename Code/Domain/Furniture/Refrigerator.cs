using Domain.Actions;
using System.Collections.Generic;
using System.Numerics;

namespace Domain.Furniture
{
    public class Refrigerator : IInteractable
    {
        public Refrigerator(int hunger, Vector3 at)
        {
            Food = new Food(repletion: hunger);
            Position = at;
        }

        public Food Food { get; }

        public Vector3 Position { get; }

        public IEnumerable<Action> AvailableActions() => new List<Action> { new Eat(from: this) };
    }
}