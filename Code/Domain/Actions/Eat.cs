namespace Domain.Actions
{
    public class Eat : Action
    {
        protected override string Name => nameof(Eat);

        public override void Perform(Sim performer)
        {
            // TODO: Review how to parameterize the Food to be eaten.
            performer.Eat(new Food(10));
        }
    }
}