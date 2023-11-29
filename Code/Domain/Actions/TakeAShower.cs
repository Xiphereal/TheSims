using Domain.Furniture;

namespace Domain.Actions
{
    // TODO: Is there a common term between taking a shower and a bath?
    public class TakeAShower : Action
    {
        private HygieneRestorer hygieneRestorer;

        public TakeAShower(HygieneRestorer hygieneRestorer)
            : base(hygieneRestorer.Position)
        {
            this.hygieneRestorer = hygieneRestorer;
        }

        public override string Name => nameof(TakeAShower);

        public override System.TimeSpan Duration => System.TimeSpan.FromSeconds(15);

        public override void Perform(Sim performer)
        {
            performer.RestoreHygiene();
        }
    }
}