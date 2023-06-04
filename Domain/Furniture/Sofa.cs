using Domain.Actions;
using System.Collections.Generic;

namespace Domain.Furniture
{
    public class Sofa : ISleepable
    {
        public IEnumerable<IAction> AvailableActions()
        {
            throw new System.NotImplementedException();
        }
    }
}