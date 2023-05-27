using Domain.Furniture;

namespace Domain.Actions
{
    public class UseToilet : IAction
    {
        private IBladderRestorer bladderRestorer;

        public UseToilet(IBladderRestorer bladderRestorer)
        {
            this.bladderRestorer = bladderRestorer;
        }

        public void Perform(Sim performer)
        {
            performer.RestoreBladder();
        }
    }
}