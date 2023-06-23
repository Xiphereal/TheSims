using Domain.Actions;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Furniture
{
    public class Sofa : Sleepable
    {
        public override IEnumerable<Action> AvailableActions()
        {
            return base.AvailableActions().Append(new Sit(this));
        }
    }
}