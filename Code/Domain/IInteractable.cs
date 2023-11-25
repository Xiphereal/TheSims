using Domain.Actions;
using System.Collections.Generic;
using System.Numerics;

namespace Domain
{
    public interface IInteractable
    {
        Vector3 Position { get; }

        IEnumerable<Action> AvailableActions();
    }
}