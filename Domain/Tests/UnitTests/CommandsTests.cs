using Domain.Actions;
using Domain.Furniture;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;
using static Domain.Tests.Builders.LotBuilder;
using static Domain.Tests.Builders.SimBuilder;

namespace Domain.Tests.UnitTests
{
    public class CommandsTests
    {
        private static readonly TimeSpan AnyTimeSpan = TimeSpan.FromHours(1);

        [Fact]
        public void Actions_can_be_commanded()
        {
            // Arrange.
            Time time = new();
            Lot lot = Lot().With(time).Build();

            const int initialComfort = 50;
            Sim sim = Sim().WithComfort(initialComfort).Build();

            lot.EnteredBy(sim);

            // Act.
            sim.Command(new Sit(on: new Sofa()));
            sim.Comfort.Should().Be(50);

            time.Forward(AnyTimeSpan);

            // Assert.
            sim.Comfort.Should().BeGreaterThan(initialComfort);
        }

        [Fact]
        public void Actions_can_be_canceled()
        {
            // Arrange.
            Time time = new();
            Lot lot = Lot().With(time).Build();

            const int initialComfort = 50;
            Sim sim = Sim().WithComfort(initialComfort).Build();

            lot.EnteredBy(sim);

            Sit action = new(on: new Sofa());
            sim.Command(action);
            sim.Comfort.Should().Be(50);

            // Act.
            sim.Cancel(action);

            time.Forward(AnyTimeSpan);

            // Assert.
            sim.Comfort.Should().BeCloseTo(initialComfort, delta: 5);
        }

        [Fact]
        public void Beds_can_be_used_to_get_laid_and_sleep()
        {
            Bed bed = new();

            var actions = bed.AvailableActions();

            actions.Select(x => x.GetType())
                .Should().BeEquivalentTo(new[] { typeof(Sleep), typeof(Lay) });
        }
    }
}