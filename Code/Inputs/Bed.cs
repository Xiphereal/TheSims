namespace Godot
{
    public partial class Bed : Node
    {
        public override void _Input(InputEvent @event)
        {
            GD.Print(@event.AsText());
        }
    }
}