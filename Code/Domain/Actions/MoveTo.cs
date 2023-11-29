using Domain.Actions;
using System.Numerics;

namespace Domain
{
    public class MoveTo : Action
    {
        private Vector3 destination;

        public MoveTo(Vector3 destination)
            : base(destination)
        {
            this.destination = destination;
        }

        public override string Name => "Move here";

        // TODO: this will cause mayhem when the Sim actually moves rather than
        // teleports to the destination. This action should be separated from
        // the rest: apart from this duration aspect, it has no limitation
        // regarding the Sim position relative to the destination point.
        public override System.TimeSpan Duration => System.TimeSpan.FromSeconds(1);

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