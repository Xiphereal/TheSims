using FluentAssertions;
using Xunit;

namespace Domain.Tests
{
    public class SimsNeedsTests
    {
        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        public void Hunger_is_replenished_depending_on_the_given_food(int foodRepletion)
        {
            const int initialHunger = 80;
            Sim sut = new(initialHunger);

            sut.Eat(new Food(foodRepletion));

            sut.Hunger.Should().Be(initialHunger + foodRepletion);
        }

        [Fact]
        public void Hunger_cannot_overflows()
        {
            Sim sut = new(hunger: 100);

            sut.Eat(new Food(repletion: 1));

            sut.Hunger.Should().Be(100);
        }
    }
}