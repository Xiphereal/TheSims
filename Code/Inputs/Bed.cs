using Domain;

namespace Godot
{
    public partial class Bed : Interactable
    {
        protected override IInteractable GetInteractable()
        {
            return new Domain.Furniture.Bed();
        }
    }
}