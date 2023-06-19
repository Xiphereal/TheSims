using Domain;
using Domain.Actions;
using System.Collections.Generic;

namespace Control
{
    public class Player
    {
        public IEnumerable<IAction> InteractWith(IInteractable interactable)
        {
            return interactable.AvailableActions();
        }
    }
}