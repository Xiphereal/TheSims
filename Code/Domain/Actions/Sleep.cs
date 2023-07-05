using Domain.Furniture;

namespace Domain.Actions
{
    public class Sleep : Action
    {
        private Sleepable sleepable;

        public Sleep(Sleepable on)
        {
            sleepable = on;
        }

        protected override string Name => nameof(Sleep);

        public override void Perform(Sim performer)
        {
            performer.Sleep();
        }
    }
}