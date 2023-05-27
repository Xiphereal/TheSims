using Domain.Furniture;

namespace Domain.Actions
{
    public class Sleep : IAction
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