using AutoMoq;
using NUnit.Framework;

namespace Kata.Tests.Infrastructure
{
    public class MockistTestBase<T>
        where T : class
    {
        protected AutoMoqer Mocks;
        protected T SUT;
        
        [TestFixtureSetUp]
        public virtual void Init()
        {
            Mocks = new AutoMoqer();
            SUT = Mocks.Resolve<T>();

            Arrange();
            Act();
        }

        [TestFixtureTearDown]
        public virtual void TestCleanup() 
        {
            Finally();
        }

        public virtual void Arrange() {}
        public virtual void Act() {}
        public virtual void Finally() {}
    }
}