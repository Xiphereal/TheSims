using Domain.Actions;
using System.Numerics;

namespace Domain
{
    public class MoveTo : Action
    {
        private Vector3 point;

        public MoveTo(Vector3 point)
        {
            this.point = point;
        }

        protected override string Name => throw new System.NotImplementedException();

        public override void Perform(Sim performer)
        {
            throw new System.NotImplementedException();
        }

        public override bool Equals(object other)
        {
            return other is MoveTo otherMoveTo
                && point.Equals(otherMoveTo.point);
        }
    }
}