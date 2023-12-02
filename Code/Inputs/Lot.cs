using Domain.Actions;
using Godot;
using System.Linq;

namespace Inputs
{
    public partial class Lot : Node3D
    {
        private readonly Domain.Time time = new();

        public Domain.Lot DomainLot { get; private set; }

        public override void _Ready()
        {
            DomainLot = new(time);
            Domain.Sim sim = FindAnySimInScene();
            DomainLot.EnteredBy(sim);
            sim.ActionPerformed += OnActionPerformed;
        }

        private void OnActionPerformed(Action performed)
        {
            FindUI().GetChild<BoxContainer>(idx: 0)
                .GetChildren().OfType<Button>()
                .First(x => x.Name.ToString().StartsWith(performed.Name))
                .QueueFree();
        }

        private Godot.UI FindUI()
        {
            return GetNode<Godot.UI>("/root/Root/UI");
        }

        private Domain.Sim FindAnySimInScene()
        {
            return GetNode<SimInput>("Sim").Sim;
        }

        public void OnTimeTimeout()
        {
            time.Forward();
        }
    }
}