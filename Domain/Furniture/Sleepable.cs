using Domain.Actions;
using System.Collections.Generic;

namespace Domain.Furniture
{
    public abstract class Sleepable : IInteractable
    {
        public virtual IEnumerable<IAction> AvailableActions() => new List<IAction> { new Sleep(this), new Lay() };
    }
}