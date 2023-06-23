using Domain.Furniture;

namespace Domain.Actions
{
    public class Sit : Action
    {
        private Sofa on;

        public Sit(Sofa on)
        {
            this.on = on;
        }

        public override string Name => nameof(Sit);

        public override void Perform(Sim performer)
        {
            performer.RestoreComfort();
        }
    }
}