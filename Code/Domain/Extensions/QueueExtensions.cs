using Domain.Actions;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Extensions
{
    internal static class QueueExtensions
    {
        public static Queue<Action> Without(this Queue<Action> actions, Action action)
        {
            return new Queue<Action>(actions.Where(x => !x.Equals(action)));
        }
    }
}