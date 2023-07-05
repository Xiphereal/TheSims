using Domain.Furniture;

namespace Domain.Actions
{
    public class UseToilet : Action
    {
        private IBladderRestorer bladderRestorer;

        public UseToilet(IBladderRestorer bladderRestorer)
        {
            this.bladderRestorer = bladderRestorer;
        }

        protected override string Name => nameof(UseToilet);

        public override void Perform(Sim performer)
        {
            performer.RestoreBladder();
        }
    }
}