using Control;

namespace Godot
{
    public partial class PlayerInput : Node3D
    {
        public Player Player { get; set; } = new Player();

        public override void _Ready()
        {
            Player.ActiveSim(FindAnySimInScene());
        }

        private Domain.Sim FindAnySimInScene()
        {
            return GetNode<SimInput>("../Sim").Sim;
        }
    }
}