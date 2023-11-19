using Domain.Actions;
using System.Numerics;

namespace Domain
{
    public class MoveTo : Action
    {
        private Vector3 destination;

        public MoveTo(Vector3 destination)
        {
            this.destination = destination;
        }

        protected override string Name => "Move here";

        public override void Perform(Sim performer)
        {
            performer.Position = destination;
        }

        public override bool Equals(object other)
        {
            return other is MoveTo otherMoveTo
                && destination.Equals(otherMoveTo.destination);
        }
    }
}