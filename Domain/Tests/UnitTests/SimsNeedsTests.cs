using Domain.Actions;
using Domain.Furniture;
using FluentAssertions;
using Xunit;
using static Domain.Tests.Builders.SimBuilder;

namespace Domain.Tests.UnitTests
{
    public class SimsNeedsTests
    {
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

            sut.Hunger.Should().BeLessThanOrEqualTo(100);
        }

        [Fact]
        public void Hygiene_is_restored_by_showering()
        {
            Sim sut = Sim().WithHygiene(80).Build();

            sut.Use(new Shower());

            sut.Hygiene.Should().Be(100);
        }

        [Fact]
        public void Hygiene_is_restored_by_bathing()
        {
            Sim sut = Sim().WithHygiene(80).Build();

            sut.Use(new Bath());

            sut.Hygiene.Should().Be(100);
        }

        [Fact]
        public void Hygiene_cannot_overflow()
        {
            Sim sut = Sim().Build();

            sut.Use(new Shower());

            sut.Hygiene.Should().BeLessThanOrEqualTo(100);
        }

        [Fact]
        public void Both_Energy_and_Comfort_are_restored_by_sleeping_on_bed()
        {
            Sim sut = Sim().WithEnergy(80).WithComfort(80).Build();

            sut.Perform(new Sleep(on: new Bed()));

            sut.Energy.Should().Be(100);
            sut.Comfort.Should().Be(100);
        }

        [Fact]
        public void Both_Energy_and_Comfort_are_restored_by_sleeping_on_sofa()
        {
            Sim sut = Sim().WithEnergy(80).WithComfort(80).Build();

            sut.Perform(new Sleep(on: new Sofa()));

            sut.Energy.Should().Be(100);
            sut.Comfort.Should().Be(100);
        }

        [Fact]
        public void Energy_cannot_overflow()
        {
            Sim sut = Sim().Build();

            sut.Perform(new Sleep(on: new Sofa()));

            sut.Energy.Should().BeLessThanOrEqualTo(100);
        }

        [Fact]
        public void Comfort_is_restored_by_sitting()
        {
            Sim sut = Sim().WithComfort(80).Build();

            sut.Perform(new Sit(on: new Sofa()));

            sut.Comfort.Should().Be(100);
        }

        [Fact]
        public void Comfort_cannot_overflow()
        {
            Sim sut = Sim().Build();

            sut.Perform(new Sit(on: new Sofa()));

            sut.Comfort.Should().BeLessThanOrEqualTo(100);
        }
    }
}