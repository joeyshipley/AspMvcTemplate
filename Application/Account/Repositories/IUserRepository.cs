using System;
using System.Collections.Generic;
using ThinkCraft.Application.Account.Entities;

namespace ThinkCraft.Application.Account.Repositories
{
    public interface IUserRepository
    {
        IList<User> Find(Func<User, bool> filter);
        User Find(Guid id);
        User Find(string email);
        void Save(User user);
    }
}