namespace Domain.Actions
{
    public class Lay : Action
    {
        public override string Name => nameof(Lay);

        public override void Perform(Sim performer)
        {
            performer.Sleep();
        }
    }
}