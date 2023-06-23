using Domain.Actions;
using System.Collections.Generic;

namespace Domain.Furniture
{
    public abstract class Sleepable : IInteractable
    {
        public virtual IEnumerable<Action> AvailableActions() => new List<Action> { new Sleep(this), new Lay() };
    }
}