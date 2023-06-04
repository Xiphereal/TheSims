using Domain.Actions;
using System.Collections.Generic;

namespace Domain.Furniture
{
    public class Shower : IHygieneRestorer
    {
        public IEnumerable<IAction> AvailableActions()
        {
            throw new System.NotImplementedException();
        }
    }
}