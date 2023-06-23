using Domain.Actions;
using System.Collections.Generic;

namespace Domain.Furniture
{
    public class Toilet : IBladderRestorer
    {
        public IEnumerable<Action> AvailableActions() => new List<Action> { new UseToilet(this) };
    }
}