using Domain.Actions;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Extensions
{
    internal static class QueueExtensions
    {
        public static Queue<IAction> Without(this Queue<IAction> actions, IAction action)
        {
            return new Queue<IAction>(actions.Where(x => !x.Equals(action)));
        }
    }
}