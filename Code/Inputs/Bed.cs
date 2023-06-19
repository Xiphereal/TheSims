using Control;

namespace Godot
{
    public partial class Bed : Node3D
    {
        private Player player;
        private bool isMouseOver = false;

        public override void _Ready()
        {
            player = new Player();
        }

        public override void _Input(InputEvent @event)
        {
            if (@event is InputEventMouseButton mouseButton
                && mouseButton.Pressed
                && isMouseOver)
            {
                GD.Print(string.Join(", ", player.InteractWith(new Domain.Furniture.Bed())));
            }
        }

        public void OnMatressMouseEntered()
        {
            isMouseOver = true;
        }

        public void OnMatressMouseExited()
        {
            isMouseOver = false;
        }
    }
}