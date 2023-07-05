using Domain;
using Domain.Actions;
using System.Collections.Generic;

namespace Control
{
    public class Player
    {
        private Sim activeSim;

        public void ActiveSim(Sim sim)
        {
            activeSim = sim;
        }

        public void Command(Action action)
        {
            activeSim.Command(action);
        }

        public IEnumerable<Action> InteractWith(IInteractable interactable)
        {
            return interactable.AvailableActions();
        }
    }
}