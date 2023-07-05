using System.Collections.Generic;
using Domain.Actions;

namespace Domain.Furniture
{
    public class Refrigerator : IInteractable
    {
        public IEnumerable<Action> AvailableActions() => new List<Action> { new Eat() };
    }
}