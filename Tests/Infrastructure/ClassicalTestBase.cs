using NUnit.Framework;
using StructureMap;
using ThinkCraft.WebClient.Infrastructure.IoC;

namespace ThinkCraft.Tests.Infrastructure
{
    public class ClassicalTestBase<T>
        where T : class
    {
        protected T SUT;
        
        [TestFixtureSetUp]
        public virtual void Init()
        {
            // TODO: create ability to pass in a fake
            IoCConfiguration.BuildContainer();
            SUT = ObjectFactory.GetInstance<T>();

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