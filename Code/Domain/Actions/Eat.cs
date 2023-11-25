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

        public override void Perform(Sim performer)
        {
            performer.Eat(refrigerator.Food);
        }
    }
}