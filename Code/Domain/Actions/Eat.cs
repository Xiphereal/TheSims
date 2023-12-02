using Domain.Furniture;

namespace Domain.Actions
{
    public class Eat : Action
    {
        private readonly Refrigerator refrigerator;

        public Eat(Refrigerator from)
            : base(from.Position)
        {
            refrigerator = from;
        }

        public override string Name => nameof(Eat);

        public override System.TimeSpan Duration => System.TimeSpan.FromSeconds(4);

        public override void ContinuePerforming(Sim performer)
        {
            base.ContinuePerforming(performer);
            performer.Eat(refrigerator.Food);
        }
    }
}