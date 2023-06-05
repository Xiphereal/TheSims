using Domain.Furniture;
using Xunit;

namespace Control.Tests.UnitTests
{
    public class PlayerTests
    {
        [Fact]
        public void TestName()
        {
            var sut = new Player();

            sut.InteractWith(new Bed());
        }
    }
}