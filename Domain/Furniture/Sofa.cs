using Domain.Actions;
using System;
using System.Collections.Generic;

namespace Domain.Furniture
{
    public class Sofa : IUsable
    {
        public IEnumerable<IAction> AvailableActions()
        {
            throw new NotImplementedException();
        }

        public void Use(Sim user)
        {
            user.Sleep();
        }
    }
}