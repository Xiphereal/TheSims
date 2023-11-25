using Domain;
using Domain.Actions;
using Domain.Furniture;
using FluentAssertions;
using System.Collections.Generic;
using System.Numerics;
using Xunit;
using static Domain.Tests.Builders.SimBuilder;

namespace Control.Tests.UnitTests
{
    public class PlayerTests
    {
        [Fact]
        public void Available_actions_for_interactable_can_be_queried()
        {
            Player sut = new();
            Bed anyInteractable = new();

            IEnumerable<Action> result = sut.InteractWith(anyInteractable);

            result.Should().NotBeEmpty();
        }

        [Fact]
        public void Choosen_action_is_commanded_to_active_sim()
        {
            const int initialEnergy = 0;
            Sim activeSim = Sim().WithEnergy(initialEnergy).Build();
            Player sut = new();
            sut.ActiveSim(activeSim);
            Sleep sleep = new(new Bed());

            sut.Command(sleep);

            activeSim.PerformNextAction();
            activeSim.Energy.Should().BeGreaterThan(initialEnergy);
        }

        [Fact]
        public void Sim_performs_queued_actions_due_to_pass_of_time()
        {
            Sim activeSim = Sim().Build();
            activeSim.Position = Vector3.Zero;

            Player sut = new();
            sut.ActiveSim(activeSim);
            Time time = new();
            Lot lot = new(time);
            lot.EnteredBy(activeSim);

            Vector3 destination = Vector3.One;
            sut.Command(new MoveTo(destination));

            time.Forward(System.TimeSpan.FromSeconds(1));

            activeSim.Position.Should().Be(destination);
        }
    }
}