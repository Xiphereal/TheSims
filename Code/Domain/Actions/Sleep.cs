using Domain.Furniture;

namespace Domain.Actions
{
    public class Sleep : Action
    {
        private Sleepable sleepable;

        public Sleep(Sleepable on)
            : base(on.Position)
        {
            sleepable = on;
        }

        public override string Name => nameof(Sleep);

        public override void Perform(Sim performer)
        {
            performer.Sleep();
        }
    }
}