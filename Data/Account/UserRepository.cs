using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Linq;
using ThinkCraft.Application.Account.Entities;
using ThinkCraft.Application.Account.Repositories;
using ThinkCraft.Data.Infrastructure;

namespace ThinkCraft.Data.Account
{
    public class UserRepository : IUserRepository
    {
        private readonly ISessionWorker _worker;

        public UserRepository(ISessionWorker sessionWorker)
        {
            _worker = sessionWorker;
        }

        public IList<User> Find(Func<User, bool> filter)
        {
            return _worker.Perform((session) =>
                session.Query<User>()
                    .Where(filter)
                    .ToList()
            );
        }

        public User Find(string email)
        {
            var user = _worker.Perform((session) => 
                session.Query<User>()
                    .FirstOrDefault(u => u.Email.ToLower() == email.ToLower())
            );
            return user;
        }

        public User Find(Guid id)
        {
            return _worker.Perform((session) => 
                session.Get<User>(id)
            );
        }

        public void Save(User user)
        {
            _worker.Perform((session) => 
                session.Save(user)
            );
        }
    }
}