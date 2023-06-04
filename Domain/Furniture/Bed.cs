using Domain.Actions;
using System.Collections.Generic;

namespace Domain.Furniture
{
    public class Bed : ISleepable
    {
        public IEnumerable<IAction> AvailableActions() => new List<IAction> { new Sleep(this), new Lay() };
    }
}