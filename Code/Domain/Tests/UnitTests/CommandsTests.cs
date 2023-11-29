using Domain.Actions;
using Domain.Furniture;
using FluentAssertions;
using FluentAssertions.Extensions;
using System.Linq;
using System.Numerics;
using Xunit;
using static Domain.Tests.Builders.LotBuilder;
using static Domain.Tests.Builders.SimBuilder;

namespace Domain.Tests.UnitTests
{
    public class CommandsTests
    {
        private const int MinimumNeedValue = 0;

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
            sim.Command(new Sit(on: new Sofa(at: Vector3.Zero)));
            sim.Comfort.Should().Be(50);

            time.Forward();

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

            Sit action = new(on: new Sofa(at: Vector3.Zero));
            sim.Command(action);
            sim.Comfort.Should().Be(50);

            // Act.
            sim.Cancel(action);

            time.Forward();

            // Assert.
            sim.Comfort.Should().BeCloseTo(initialComfort, delta: 5);
        }

        [Fact]
        public void Performed_actions_are_notified()
        {
            Sim sim = Sim().Build();

            Action performedAction = null;
            sim.ActionPerformed += delegate (Action action)
            {
                performedAction = action;
            };

            Sleep action = new(new Bed(at: Vector3.Zero));
            sim.Perform(action);

            performedAction.Should().Be(action);
        }

        [Fact]
        public void Sim_can_be_commanded_to_move_to_point()
        {
            Vector3 point = new(x: 1, y: 1, z: 1);

            new Floor(point)
                .AvailableActions()
                .Should().BeEquivalentTo(new[] { new MoveTo(point) });
        }

        [Fact]
        public void Sim_can_reach_destination_by_moving()
        {
            // Arrange.
            Time time = new();
            Lot lot = Lot().With(time).Build();
            Sim sim = Sim().Build();
            lot.EnteredBy(sim);

            sim.Position = Vector3.Zero;

            Vector3 destination = Vector3.One;
            sim.Command(new MoveTo(destination));

            // Act.
            time.Forward();

            // Assert.
            sim.Position.Should().Be(destination);
        }

        [Fact]
        public void Sim_teleports_to_interactable_when_far_away()
        {
            Sim sim = Sim().At(Vector3.Zero).Build();

            Toilet toilet = new(at: Vector3.One * 999999);
            sim.Command(new UseToilet(toilet));
            sim.ContinuePerformingActionAtHand();

            sim.Position.Should().Be(toilet.Position);
        }

        [Fact]
        public void Actions_take_a_while_to_complete()
        {
            Time time = new();
            Lot lot = Lot().With(time).Build();
            Sim sim = SimWithAllNeedsToMinimum().At(Vector3.Zero).Build();
            lot.EnteredBy(sim);

            Action action = new Sit(on: new Sofa(at: sim.Position));
            sim.Command(action);

            action.Duration = 10.Seconds();

            time.Forward(howMuch: 1);
            sim.Comfort.Should().Be(MinimumNeedValue);

            time.Forward(howMuch: 10);
            sim.Comfort.Should().BeGreaterThan(MinimumNeedValue);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        public void Eating_replenish_hunger_depending_on_the_Refrigerator_used(int refrigeratorHunger)
        {
            const int initialHunger = 80;
            Sim sim = Builders.SimBuilder.Sim().WithHunger(initialHunger).Build();

            new Eat(
                    from: new Refrigerator(
                        hunger: refrigeratorHunger,
                        at: Vector3.Zero))
                .Perform(sim);

            sim.Hunger.Should().Be(initialHunger + refrigeratorHunger);
        }

        [Fact]
        public void Beds_can_be_used_to_lie_down_and_sleep()
        {
            new Bed(at: Vector3.Zero)
                .AvailableActions().Select(x => x.GetType())
                .Should().BeEquivalentTo(new[] { typeof(Lay), typeof(Sleep) });
        }

        [Fact]
        public void Sofa_can_be_used_to_sit_lie_down_and_sleep()
        {
            new Sofa(at: Vector3.Zero)
                .AvailableActions().Select(x => x.GetType())
                .Should().BeEquivalentTo(new[] { typeof(Sit), typeof(Lay), typeof(Sleep) });
        }

        [Fact]
        public void Showers_can_be_used_to_take_a_shower()
        {
            new Shower(at: Vector3.Zero)
                .AvailableActions().Select(x => x.GetType())
                .Should().BeEquivalentTo(new[] { typeof(TakeAShower) });
        }

        [Fact]
        public void Baths_can_be_used_to_take_a_bath()
        {
            new Bath(at: Vector3.Zero)
                .AvailableActions().Select(x => x.GetType())
                .Should().BeEquivalentTo(new[] { typeof(TakeAShower) });
        }

        [Fact]
        public void Toilets_can_be_used_to_relieve_bladder()
        {
            new Toilet(at: Vector3.Zero)
                .AvailableActions().Select(x => x.GetType())
                .Should().BeEquivalentTo(new[] { typeof(UseToilet) });
        }
    }
}