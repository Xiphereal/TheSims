using Domain.Furniture;

namespace Domain.Actions
{
    public struct Sleep : IAction
    {
        private Sleepable sleepable;

        public Sleep(Sleepable on)
        {
            sleepable = on;
        }

        public void Perform(Sim performer)
        {
            performer.Sleep();
        }
    }
}