using Domain;
using Domain.Actions;
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
            Sim.ActionPerformed += Alkdfhalsdfh;
        }

        private void Alkdfhalsdfh(Action performed)
        {
            Position = performed.InteractablePosition.ToGodotVector();
        }
    }
}