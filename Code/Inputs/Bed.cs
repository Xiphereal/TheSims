using Control;

namespace Godot
{
    public partial class Bed : Node3D
    {
        private Player player;

        public override void _Ready()
        {
            player = new Player();
        }

        public void OnAreaInputEvent(Node camera, InputEvent @event, Vector3 position, Vector3 normal, long shapeIdx)
        {
            if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed)
            {
                GD.Print(string.Join(", ", player.InteractWith(new Domain.Furniture.Bed())));
            }
        }
    }
}