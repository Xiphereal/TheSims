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
        public void Hunger_cannot_overflows()
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
    }
}