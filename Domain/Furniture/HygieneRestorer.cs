using Domain.Actions;
using System.Collections.Generic;

namespace Domain.Furniture
{
    public abstract class HygieneRestorer : IInteractable
    {
        public IEnumerable<IAction> AvailableActions() => new List<IAction> { new TakeAShower(this) };
    }
}