using Domain.Furniture;

namespace Domain.Actions
{
    // TODO: Is there a common term between taking a shower and a bath?
    public class TakeAShower : Action
    {
        private HygieneRestorer hygieneRestorer;

        public TakeAShower(HygieneRestorer hygieneRestorer)
        {
            this.hygieneRestorer = hygieneRestorer;
        }

        protected override string Name => nameof(TakeAShower);

        public override void Perform(Sim performer)
        {
            performer.RestoreHygiene();
        }
    }
}