using Domain.Actions;
using Domain.Furniture;
using System.Collections.Generic;

namespace Control
{
    public class Player
    {
        public IEnumerable<IAction> InteractWith(Bed bed)
        {
            return bed.AvailableActions();
        }
    }
}