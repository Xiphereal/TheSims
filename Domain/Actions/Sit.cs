using Domain.Furniture;

namespace Domain.Actions
{
    public class Sit : IAction
    {
        private Sofa on;

        public Sit(Sofa on)
        {
            this.on = on;
        }

        public void Perform(Sim performer)
        {
            performer.RestoreComfort();
        }
    }
}