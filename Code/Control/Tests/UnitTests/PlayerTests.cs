using Domain;
using Domain.Actions;
using Domain.Furniture;
using FluentAssertions;
using System.Collections.Generic;
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
    }
}