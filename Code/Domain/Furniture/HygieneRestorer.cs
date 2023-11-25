using Domain.Actions;
using System.Collections.Generic;
using System.Numerics;

namespace Domain.Furniture
{
    public abstract class HygieneRestorer : IInteractable
    {
        public HygieneRestorer(Vector3 at)
        {
            Position = at;
        }

        public Vector3 Position { get; }

        public IEnumerable<Action> AvailableActions() =>
            new List<Action> { new TakeAShower(this) };
    }
}