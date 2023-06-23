using Domain.Actions;
using System.Collections.Generic;

namespace Domain
{
    public interface IInteractable
    {
        IEnumerable<Action> AvailableActions();
    }
}