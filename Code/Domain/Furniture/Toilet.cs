using Domain.Actions;
using System.Collections.Generic;
using System.Numerics;

namespace Domain.Furniture
{
    public class Toilet : IBladderRestorer
    {
        private Vector3 at;

        public Toilet(Vector3 at)
        {
            this.at = at;
        }

        public Vector3 Position => at;

        public IEnumerable<Action> AvailableActions()
            => new List<Action> { new UseToilet(this) };
    }
}