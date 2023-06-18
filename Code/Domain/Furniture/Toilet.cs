using Domain.Actions;
using System.Collections.Generic;

namespace Domain.Furniture
{
    public class Toilet : IBladderRestorer
    {
        public IEnumerable<IAction> AvailableActions() => new List<IAction> { new UseToilet(this) };
    }
}