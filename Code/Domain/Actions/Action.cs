using System;
using System.Numerics;

namespace Domain.Actions
{
    public abstract class Action
    {
        private TimeSpan elapsed;

        public Action(Vector3 interactablePosition)
        {
            InteractablePosition = interactablePosition;
        }

        public abstract string Name { get; }

        public Vector3 InteractablePosition { get; }
        public abstract TimeSpan Duration { get; }
        public bool IsOver { get; set; }

        public virtual void ContinuePerforming(Sim performer)
        {
            elapsed += TimeSpan.FromSeconds(1);

            IsOver = elapsed >= Duration;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}