namespace Godot
{
    public partial class ActionButton : Button
    {
        public override void _Pressed()
        {
            QueueFree();
        }
    }
}