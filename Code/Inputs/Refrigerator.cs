using Domain;

namespace Godot
{
    public partial class Refrigerator : Interactable
    {
        [Export(PropertyHint.Range, "1,100")]
        private int hunger;

        protected override IInteractable GetInteractable()
        {
            return new Domain.Furniture.Refrigerator(hunger);
        }
    }
}