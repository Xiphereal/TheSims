using Domain.Furniture;

namespace Domain.Actions
{
    public struct Sleep : IAction
    {
        private ISleepable sleepable;

        public Sleep(ISleepable on)
        {
            sleepable = on;
        }

        public void Perform(Sim performer)
        {
            performer.Sleep();
        }
    }
}