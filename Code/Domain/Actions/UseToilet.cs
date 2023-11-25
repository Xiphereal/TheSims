using Domain.Furniture;

namespace Domain.Actions
{
    public class UseToilet : Action
    {
        private readonly IBladderRestorer bladderRestorer;

        public UseToilet(
            IBladderRestorer bladderRestorer)
            : base(bladderRestorer.Position)
        {
            this.bladderRestorer = bladderRestorer;
        }

        public override string Name => nameof(UseToilet);

        public override void Perform(Sim performer)
        {
            performer.RestoreBladder();
        }
    }
}