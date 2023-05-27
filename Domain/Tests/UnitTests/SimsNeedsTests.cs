using Domain.Actions;
using Domain.Furniture;
using FluentAssertions;
using System;
using Xunit;
using static Domain.Tests.Builders.SimBuilder;

namespace Domain.Tests.UnitTests
{
    public class SimsNeedsTests
    {
        private const int NeedMaxValue = 100;

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

            sut.Perform(new TakeAShower(new Shower()));

            sut.Hygiene.Should().Be(NeedMaxValue);
        }

        [Fact]
        public void Hygiene_is_restored_by_bathing()
        {
            Sim sut = Sim().WithHygiene(80).Build();

            sut.Perform(new TakeAShower(new Bath()));

            sut.Hygiene.Should().Be(NeedMaxValue);
        }

        [Fact]
        public void Hygiene_cannot_overflow()
        {
            Sim sut = Sim().Build();

            sut.Perform(new TakeAShower(new Shower()));

            sut.Hygiene.Should().BeLessThanOrEqualTo(NeedMaxValue);
        }

        [Fact]
        public void Bladder_is_relieved_by_using_a_toilet()
        {
            Sim sut = Sim().WithBladder(80).Build();

            sut.Perform(new UseToilet(new Toilet()));

            sut.Bladder.Should().Be(NeedMaxValue);
        }

        [Fact]
        public void Bladder_cannot_overflow()
        {
            Sim sut = Sim().Build();

            sut.Perform(new UseToilet(new Toilet()));

            sut.Bladder.Should().BeLessThanOrEqualTo(NeedMaxValue);
        }

        [Fact]
        public void Both_Energy_and_Comfort_are_restored_by_sleeping_on_bed()
        {
            Sim sut = Sim().WithEnergy(80).WithComfort(80).Build();

            sut.Perform(new Sleep(on: new Bed()));

            sut.Energy.Should().Be(NeedMaxValue);
            sut.Comfort.Should().Be(NeedMaxValue);
        }

        [Fact]
        public void Both_Energy_and_Comfort_are_restored_by_sleeping_on_sofa()
        {
            Sim sut = Sim().WithEnergy(80).WithComfort(80).Build();

            sut.Perform(new Sleep(on: new Sofa()));

            sut.Energy.Should().Be(NeedMaxValue);
            sut.Comfort.Should().Be(NeedMaxValue);
        }

        [Fact]
        public void Energy_cannot_overflow()
        {
            Sim sut = Sim().Build();

            sut.Perform(new Sleep(on: new Sofa()));

            sut.Energy.Should().BeLessThanOrEqualTo(NeedMaxValue);
        }

        [Fact]
        public void Comfort_is_restored_by_sitting()
        {
            Sim sut = Sim().WithComfort(80).Build();

            sut.Perform(new Sit(on: new Sofa()));

            sut.Comfort.Should().Be(NeedMaxValue);
        }

        [Fact]
        public void Comfort_cannot_overflow()
        {
            Sim sut = Sim().Build();

            sut.Perform(new Sit(on: new Sofa()));

            sut.Comfort.Should().BeLessThanOrEqualTo(NeedMaxValue);
        }

        [Fact]
        public void Needs_increase_over_time()
        {
            Time time = new();
            Lot lot = new(time);
            Sim sim = Sim().Build();
            lot.EnteredBy(sim);

            time.Forward(TimeSpan.FromHours(1));

            sim.Hunger.Should().BeLessThan(NeedMaxValue);
            sim.Hygiene.Should().BeLessThan(NeedMaxValue);
            sim.Bladder.Should().BeLessThan(NeedMaxValue);
            sim.Energy.Should().BeLessThan(NeedMaxValue);
            sim.Comfort.Should().BeLessThan(NeedMaxValue);
        }
    }
}