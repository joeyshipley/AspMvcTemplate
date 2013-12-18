using FluentAssertions;
using NUnit.Framework;

namespace ThinkCraft.Tests
{
    [TestFixture]
    public class ExampleTest
    {
        [Test]
        public void Run()
        {
            1.Should().Be(1);
        }
    }
}