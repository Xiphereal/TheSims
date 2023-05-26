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
            Sim sut = new() { Hunger = initialHunger };

            sut.Eat(new Food(foodRepletion));

            sut.Hunger.Should().Be(initialHunger + foodRepletion);
        }
    }
}