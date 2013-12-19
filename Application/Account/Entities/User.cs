using System;

namespace ThinkCraft.Application.Account.Entities
{
    public class User
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Email { get; set; }
    }
}