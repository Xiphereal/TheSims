﻿using Domain.Actions;
using Domain.Furniture;
using FluentAssertions;
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
        private const int MaximumNeedValue = 100;

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
            Sit action = new(on: new Sofa(at: Vector3.Zero));
            sim.Command(action);
            sim.Comfort.Should().Be(50);

            time.Forward(howMuch: action.Duration.Seconds);

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
        public void Sim_does_not_start_action_until_they_are_there()
        {
            Sim sim = Sim().At(Vector3.Zero).Build();

            Toilet interactable = new(at: Vector3.One * 999999);
            Action action = new UseToilet(interactable);
            sim.Command(action);
            sim.ContinuePerformingActionAtHand(during: action.Duration.Seconds);

            var performed = false;
            sim.ActionPerformed += delegate (Action a)
            {
                performed = true;
            };

            performed.Should().BeFalse();
            sim.Position.Should().NotBe(interactable.Position);
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

            time.Forward(howMuch: 1);
            sim.Comfort.Should().BeCloseTo(MinimumNeedValue, 5);

            time.Forward(howMuch: action.Duration.Seconds - 1);
            sim.Comfort.Should().BeGreaterThan(MinimumNeedValue);
        }

        [Fact]
        public void Actions_satisfy_needs_right_from_their_start()
        {
            Time time = new();
            Lot lot = Lot().With(time).Build();
            Sim sim = SimWithAllNeedsToMinimum().At(Vector3.Zero).Build();
            lot.EnteredBy(sim);

            sim.Command(new Sleep(on: new Sofa(at: sim.Position)));

            time.Forward(howMuch: 1);
            sim.Energy.Should().BeCloseTo(MinimumNeedValue, delta: 5);
        }

        [Fact]
        public void Actions_are_performed_secuencially_rather_than_in_parallel()
        {
            Time time = new();
            Lot lot = Lot().With(time).Build();
            Sim sim = SimWithAllNeedsToMinimum().At(Vector3.Zero).Build();
            lot.EnteredBy(sim);

            Action longerAction = new Sit(on: new Sofa(at: sim.Position));
            Action shorterAction = new UseToilet(new Toilet(at: sim.Position));
            longerAction.Duration.Should().BeGreaterThan(shorterAction.Duration);

            sim.Command(longerAction);
            sim.Command(shorterAction);

            time.Forward(howMuch: 1);
            var comfortAfterOneTimeUnit = sim.Comfort;
            comfortAfterOneTimeUnit.Should().BeGreaterThan(MinimumNeedValue);
            var bladderAfterOneTimeUnit = sim.Bladder;
            bladderAfterOneTimeUnit.Should().Be(MinimumNeedValue);

            time.Forward(howMuch: longerAction.Duration.Seconds - 1);
            sim.Comfort.Should().BeGreaterThan(comfortAfterOneTimeUnit);
            sim.Bladder.Should().Be(MinimumNeedValue);

            time.Forward(howMuch: shorterAction.Duration.Seconds);
            sim.Bladder.Should().BeGreaterThan(bladderAfterOneTimeUnit);
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
                .ContinuePerforming(sim);

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