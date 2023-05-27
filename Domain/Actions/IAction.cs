namespace Domain.Actions
{
    public interface IAction
    {
        void Perform(Sim performer);
    }
}