using Domain.Actions;
using System.Collections.Generic;
using System.Numerics;

namespace Domain
{
    public class Floor : IInteractable
    {
        private Vector3 point;

        public Floor(Vector3 point)
        {
            this.point = point;
        }

        public Vector3 Position { get; }

        public IEnumerable<Action> AvailableActions() => new[] { new MoveTo(point) };
    }
}