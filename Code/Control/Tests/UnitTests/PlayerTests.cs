using Domain.Actions;
using Domain.Furniture;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

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
    }
}