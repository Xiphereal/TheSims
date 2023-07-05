using Domain;

namespace Godot
{
    public partial class Refrigerator : Interactable
    {
        protected override IInteractable GetInteractable()
        {
            return new Domain.Furniture.Refrigerator();
        }
    }
}