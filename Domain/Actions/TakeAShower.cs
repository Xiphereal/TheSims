using Domain.Furniture;

namespace Domain.Actions
{
    // TODO: Is there a common term between taking a shower and a bath?
    public class TakeAShower : IAction
    {
        private HygieneRestorer hygieneRestorer;

        public TakeAShower(HygieneRestorer hygieneRestorer)
        {
            this.hygieneRestorer = hygieneRestorer;
        }

        public void Perform(Sim performer)
        {
            performer.RestoreHygiene();
        }
    }
}