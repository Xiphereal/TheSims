using Domain;

namespace Godot
{
    public partial class Refrigerator : Interactable
    {
        [Export(PropertyHint.Range, "1,100")]
        private int hunger;

        [Export(PropertyHint.ResourceType, nameof(Texture2D))]
        private Texture2D imageForAction;

        protected override IInteractable GetInteractable()
        {
            return new Domain.Furniture.Refrigerator(hunger);
        }

        protected override Texture2D GetImageForAction()
        {
            return imageForAction;
        }
    }
}