using System;
using System.Collections.Generic;
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
            populateSystemUnderTest();
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

        protected void AssignFakes(List<Action<ConfigurationExpression>> fakes)
        {
            populateSystemUnderTest(fakes);
        }
        
        private void populateSystemUnderTest()
        {
            populateSystemUnderTest(new List<Action<ConfigurationExpression>>());
        }

        private void populateSystemUnderTest(List<Action<ConfigurationExpression>> fakes)
        {
            var container = IoCConfiguration.BuildContainer(fakes);
            SUT = container.GetInstance<T>();
        }

    }
}