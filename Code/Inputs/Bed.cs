using Domain;
using Inputs.Extensions;

namespace Godot
{
    public partial class Bed : Interactable
    {
        [Export(PropertyHint.ResourceType, nameof(Texture2D))]
        private Texture2D imageForAction;

        protected override IInteractable GetInteractable()
        {
            return new Domain.Furniture.Bed(at: Position.ToNumericsVector());
        }

        protected override Texture2D GetImageForAction()
        {
            return imageForAction;
        }
    }
}