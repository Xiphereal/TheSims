namespace Domain.Actions
{
    public struct Lay : IAction
    {
        public void Perform(Sim performer)
        {
            performer.Sleep();
        }
    }
}