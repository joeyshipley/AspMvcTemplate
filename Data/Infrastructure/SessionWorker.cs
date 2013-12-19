using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using ThinkCraft.Application.Account.Entities;

namespace ThinkCraft.Data.Infrastructure
{
    public class SessionWorker : ISessionWorker
    {
        private readonly ISessionProvider _sessionProvider;

        public SessionWorker(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public T Perform<T>(Func<ISession, T> act)
        {
            T result;
            using (var session = _sessionProvider.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = act(session);
                    transaction.Commit();
                }
            }
            return result;
        }

        public void Perform(Action<ISession> act)
        {
            using (var session = _sessionProvider.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    act(session);
                    transaction.Commit();
                }
            }
        }
    }
}