using Domain.Actions;
using Domain.Furniture;
using FluentAssertions;
using System;
using System.Numerics;
using Xunit;
using static Domain.Tests.Builders.LotBuilder;
using static Domain.Tests.Builders.SimBuilder;

namespace Domain.Tests.UnitTests
{
    public class SimsNeedsTests
    {
        private const int NeedMinValue = 0;
        private const int NeedMaxValue = 100;
        private static readonly TimeSpan AnyTimeSpan = TimeSpan.FromHours(1);

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        public void Hunger_is_replenished_depending_on_the_given_food(int foodRepletion)
        {
            const int initialHunger = 80;
            Sim sut = Sim().WithHunger(initialHunger).Build();

            sut.Eat(new Food(foodRepletion));

            sut.Hunger.Should().Be(initialHunger + foodRepletion);
        }

        [Fact]
        public void Hunger_cannot_overflow()
        {
            Sim sut = Sim().Build();

            sut.Eat(new Food(repletion: 101));

            sut.Hunger.Should().BeLessThanOrEqualTo(NeedMaxValue);
        }

        [Fact]
        public void Hygiene_is_restored_by_showering()
        {
            Sim sut = Sim().WithHygiene(80).Build();

            sut.Perform(new TakeAShower(new Shower(at: Vector3.Zero)));

            sut.Hygiene.Should().BeGreaterThan(80);
        }

        [Fact]
        public void Hygiene_is_restored_by_bathing()
        {
            Sim sut = Sim().WithHygiene(80).Build();

            sut.Perform(new TakeAShower(new Bath(at: Vector3.Zero)));

            sut.Hygiene.Should().BeGreaterThan(80);
        }

        [Fact]
        public void Hygiene_cannot_overflow()
        {
            Sim sut = Sim().Build();

            sut.Perform(new TakeAShower(new Shower(at: Vector3.Zero)));

            sut.Hygiene.Should().BeLessThanOrEqualTo(NeedMaxValue);
        }

        [Fact]
        public void Bladder_is_relieved_by_using_a_toilet()
        {
            Sim sut = Sim().WithBladder(80).Build();

            sut.Perform(new UseToilet(new Toilet(at: Vector3.Zero)));

            sut.Bladder.Should().BeGreaterThan(80);
        }

        [Fact]
        public void Bladder_cannot_overflow()
        {
            Sim sut = Sim().Build();

            sut.Perform(new UseToilet(new Toilet(at: Vector3.Zero)));

            sut.Bladder.Should().BeLessThanOrEqualTo(NeedMaxValue);
        }

        [Fact]
        public void Both_Energy_and_Comfort_are_restored_by_sleeping_on_bed()
        {
            const int initial = 80;
            Sim sim = Sim()
                .WithEnergy(initial)
                .WithComfort(initial)
                .Build();

            sim.Perform(new Sleep(on: new Bed(at: Vector3.Zero)));

            sim.Energy.Should().BeGreaterThan(initial);
            sim.Comfort.Should().BeGreaterThan(initial);
        }

        [Fact]
        public void Both_Energy_and_Comfort_are_restored_by_sleeping_on_sofa()
        {
            const int initial = 80;
            Sim sim = Sim()
                .WithEnergy(initial)
                .WithComfort(initial)
                .Build();

            sim.Perform(new Sleep(on: new Sofa(at: sim.Position)));

            sim.Energy.Should().BeGreaterThan(initial);
            sim.Comfort.Should().BeGreaterThan(initial);
        }

        [Fact]
        public void Laying_restores_comfort_but_not_energy()
        {
            const int initial = 80;
            Sim sim = Sim()
                .WithEnergy(initial)
                .WithComfort(initial)
                .Build();

            sim.Perform(new Lay(sim.Position));

            sim.Comfort.Should().BeGreaterThan(initial);
            sim.Energy.Should().Be(initial);
        }

        [Fact]
        public void Energy_cannot_overflow()
        {
            Sim sut = Sim().Build();

            sut.Perform(new Sleep(on: new Sofa(at: Vector3.Zero)));

            sut.Energy.Should().BeLessThanOrEqualTo(NeedMaxValue);
        }

        [Fact]
        public void Comfort_is_restored_by_sitting()
        {
            Sim sut = Sim().WithComfort(80).Build();

            sut.Perform(new Sit(on: new Sofa(at: Vector3.Zero)));

            sut.Comfort.Should().BeGreaterThan(80);
        }

        [Fact]
        public void Comfort_cannot_overflow()
        {
            Sim sut = Sim().Build();

            sut.Perform(new Sit(on: new Sofa(at: Vector3.Zero)));

            sut.Comfort.Should().BeLessThanOrEqualTo(NeedMaxValue);
        }

        [Fact]
        public void Needs_increase_over_time()
        {
            Time time = new();
            Lot lot = Lot().With(time).Build();
            Sim sim = Sim().Build();
            lot.EnteredBy(sim);

            time.Forward();

            sim.Hunger.Should().BeLessThan(NeedMaxValue);
            sim.Hygiene.Should().BeLessThan(NeedMaxValue);
            sim.Bladder.Should().BeLessThan(NeedMaxValue);
            sim.Energy.Should().BeLessThan(NeedMaxValue);
            sim.Comfort.Should().BeLessThan(NeedMaxValue);
        }

        [Fact]
        public void Needs_increase_more_as_more_time_elapses()
        {
            Time time = new();
            Lot lot = Lot().With(time).Build();
            Sim sim = Sim().Build();
            lot.EnteredBy(sim);

            time.Forward();

            sim.Hunger.Should().BeLessThan(NeedMaxValue);
            sim.Hygiene.Should().BeLessThan(NeedMaxValue);
            sim.Bladder.Should().BeLessThan(NeedMaxValue);
            sim.Energy.Should().BeLessThan(NeedMaxValue);
            sim.Comfort.Should().BeLessThan(NeedMaxValue);

            var previousHunger = sim.Hunger;
            var previousHygiene = sim.Hygiene;
            var previousBladder = sim.Bladder;
            var previousEnergy = sim.Energy;
            var previousComfort = sim.Comfort;

            time.Forward();

            sim.Hunger.Should().BeLessThan(previousHunger);
            sim.Hygiene.Should().BeLessThan(previousHygiene);
            sim.Bladder.Should().BeLessThan(previousBladder);
            sim.Energy.Should().BeLessThan(previousEnergy);
            sim.Comfort.Should().BeLessThan(previousComfort);
        }

        [Fact]
        public void Needs_have_different_increment_rate()
        {
            Time time = new();
            Lot lot = Lot().With(time).Build();
            Sim sim = Sim().Build();
            lot.EnteredBy(sim);

            time.Forward(howMuch: 5);

            sim.Hunger
                .Should().BeLessThan(NeedMaxValue)
                .And.BeLessThan(sim.Energy);
        }

        [Fact]
        public void Needs_cannot_underflow()
        {
            Time time = new();
            Lot lot = Lot().With(time).Build();
            Sim sim = SimWithAllNeedsToMinimum().Build();
            lot.EnteredBy(sim);

            time.Forward();

            sim.Hunger.Should().BeGreaterThanOrEqualTo(NeedMinValue);
            sim.Hygiene.Should().BeGreaterThanOrEqualTo(NeedMinValue);
            sim.Bladder.Should().BeGreaterThanOrEqualTo(NeedMinValue);
            sim.Energy.Should().BeGreaterThanOrEqualTo(NeedMinValue);
            sim.Comfort.Should().BeGreaterThanOrEqualTo(NeedMinValue);
        }
    }
}