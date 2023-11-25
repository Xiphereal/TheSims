using Domain.Actions;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Domain.Furniture
{
    public class Sofa : Sleepable
    {
        public Sofa(Vector3 at)
            : base(at)
        {
        }

        public override IEnumerable<Action> AvailableActions()
        {
            return base.AvailableActions().Append(new Sit(this));
        }
    }
}