namespace Godot
{
    public partial class SimInput : CharacterBody3D
    {
        public Domain.Sim Sim { get; set; } =
            new Domain.Sim(
                new Domain.Needs(
                    hunger: 100,
                    hygiene: 100,
                    bladder: 100,
                    energy: 100,
                    confort: 100));
    }
}