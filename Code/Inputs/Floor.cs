using Domain;
using Godot;

namespace Inputs.Code.Inputs
{
    public partial class Floor : Interactable
    {
        [Export(PropertyHint.ResourceType, nameof(Texture2D))]
        private Texture2D imageForAction;

        protected override IInteractable GetInteractable()
        {
            return new Domain.Floor(System.Numerics.Vector3.Zero);
        }

        protected override Texture2D GetImageForAction()
        {
            return imageForAction;
        }
    }
}