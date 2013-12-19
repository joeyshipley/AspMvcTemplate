using NHibernate;

namespace ThinkCraft.Data.Infrastructure
{
    public interface ISessionProvider
    {
        ISession Open();
        void Close();
    }
}