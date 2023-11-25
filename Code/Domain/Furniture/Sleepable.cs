using Domain.Actions;
using System.Collections.Generic;
using System.Numerics;

namespace Domain.Furniture
{
    public abstract class Sleepable : IInteractable
    {
        public Sleepable(Vector3 at)
        {
            Position = at;
        }

        public Vector3 Position { get; }

        public virtual IEnumerable<Action> AvailableActions() =>
            new List<Action> { new Sleep(this), new Lay(Position) };
    }
}