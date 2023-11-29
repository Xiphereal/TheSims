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
            Bed anyInteractable = new(at: Vector3.Zero);

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
            Sleep sleep = new(new Bed(at: Vector3.Zero));

            sut.Command(sleep);

            activeSim.ContinuePerformingActionAtHand();
            activeSim.Energy.Should().BeGreaterThan(initialEnergy);
        }

        [Fact]
        public void Sim_performs_queued_actions_due_to_pass_of_time()
        {
            Sim activeSim = Sim()
                .WithEnergy(0)
                .Build();
            activeSim.Position = Vector3.Zero;

            Player sut = new();
            sut.ActiveSim(activeSim);
            Time time = new();
            Lot lot = new(time);
            lot.EnteredBy(activeSim);

            sut.Command(new Sleep(new Bed(at: activeSim.Position)));

            time.Forward();

            activeSim.Energy.Should().BeGreaterThan(0);
        }
    }
}