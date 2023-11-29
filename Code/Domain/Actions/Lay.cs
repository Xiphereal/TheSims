using System.Numerics;

namespace Domain.Actions
{
    public class Lay : Action
    {
        public Lay(Vector3 interactablePosition)
            : base(interactablePosition)
        {
        }

        public override string Name => nameof(Lay);

        public override System.TimeSpan Duration => System.TimeSpan.FromSeconds(10);

        public override void Perform(Sim performer)
        {
            performer.Sleep();
        }
    }
}