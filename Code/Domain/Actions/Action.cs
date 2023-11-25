namespace Domain.Actions
{
    public abstract class Action
    {
        public abstract string Name { get; }

        public abstract void Perform(Sim performer);

        public override string ToString()
        {
            return Name;
        }
    }
}