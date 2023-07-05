namespace Domain.Actions
{
    public class Lay : Action
    {
        protected override string Name => nameof(Lay);

        public override void Perform(Sim performer)
        {
            performer.Sleep();
        }
    }
}