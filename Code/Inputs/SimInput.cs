using Domain;
using Domain.Needings;
using Inputs.Extensions;

namespace Godot
{
    public partial class SimInput : CharacterBody3D
    {
        public Sim Sim { get; set; } =
            new Sim(
                new Needs(
                    hunger: 100,
                    hygiene: 100,
                    bladder: 100,
                    energy: 100,
                    confort: 100));

        public SimInput()
        {
            Sim.Position = Position.ToNumericsVector();
        }

        public override void _PhysicsProcess(double delta)
        {
            Position = Position.MoveToward(
                Sim.TargetDestination.ToGodotVector(),
                (float)delta);

            Sim.Position = Position.ToNumericsVector();
        }
    }
}