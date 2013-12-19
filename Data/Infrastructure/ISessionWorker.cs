using System;
using NHibernate;

namespace ThinkCraft.Data.Infrastructure
{
    public interface ISessionWorker
    {
        T Perform<T>(Func<ISession, T> act);
        void Perform(Action<ISession> act); 
    }
}