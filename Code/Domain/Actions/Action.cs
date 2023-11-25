using System.Numerics;

namespace Domain.Actions
{
    public abstract class Action
    {
        public Action(Vector3 interactablePosition)
        {
            InteractablePosition = interactablePosition;
        }

        public abstract string Name { get; }

        public Vector3 InteractablePosition { get; }

        public abstract void Perform(Sim performer);

        public override string ToString()
        {
            return Name;
        }
    }
}