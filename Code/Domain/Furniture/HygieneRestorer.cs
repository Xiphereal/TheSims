using Domain.Actions;
using System.Collections.Generic;

namespace Domain.Furniture
{
    public abstract class HygieneRestorer : IInteractable
    {
        public IEnumerable<Action> AvailableActions() => new List<Action> { new TakeAShower(this) };
    }
}