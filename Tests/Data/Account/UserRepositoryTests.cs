using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using StructureMap;
using ThinkCraft.Application.Account.Entities;
using ThinkCraft.Data.Account;
using ThinkCraft.Data.Infrastructure;
using ThinkCraft.Tests.Infrastructure;

namespace ThinkCraft.Tests.Data.Account.UserRepositoryTests
{
    public class When_creating_a_new_user
        : ClassicalTestBase<UserRepository>
    {
        private Guid _userId;
        private User _result;

        public override void Arrange() 
        {
            AssignFakes(new List<Action<ConfigurationExpression>>
            {
                (x => x.For<ISessionProvider>().Use<InMemorySessionProvider>())
            });
        }

        public override void Act() 
        {
            var user = new User
            {
                Email = "test@user.com"
            };
            SUT.Save(user);
            _result = SUT.Find(user.Email);
        }

        [Test]
        public void It_can_be_fetched()
        {
            _result.Email.Should().Be("test@user.com");
        }
    }
}