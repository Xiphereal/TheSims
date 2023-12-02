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

        public override System.TimeSpan Duration => System.TimeSpan.FromSeconds(20);

        public override void ContinuePerforming(Sim performer)
        {
            base.ContinuePerforming(performer);
            performer.Sleep();
        }
    }
}