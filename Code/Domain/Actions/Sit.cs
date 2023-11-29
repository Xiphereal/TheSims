using Domain.Furniture;

namespace Domain.Actions
{
    public class Sit : Action
    {
        private readonly Sofa on;

        public Sit(Sofa on)
            : base(on.Position)
        {
            this.on = on;
        }

        public override string Name => nameof(Sit);

        public override System.TimeSpan Duration => System.TimeSpan.FromSeconds(10);

        public override void Perform(Sim performer)
        {
            performer.RestoreComfort();
        }
    }
}