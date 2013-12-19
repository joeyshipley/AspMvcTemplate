using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace ThinkCraft.Data.Infrastructure
{
    public class SessionProvider : ISessionProvider
    {
        private ISessionFactory _sessionFactory;

        public ISession Open()
        {
            if(_sessionFactory == null)
                _sessionFactory = configureSessionFactory();

            return _sessionFactory.OpenSession();
        }

        public void Close()
        {
            if(_sessionFactory != null)
                _sessionFactory.Dispose();
 
            _sessionFactory = null;
        }

        private ISessionFactory configureSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(connection => connection
                        .FromConnectionStringWithKey("DefaultConnection")
                    )
                )
                .Mappings(m => 
                    m.FluentMappings.AddFromAssemblyOf<SessionProvider>()
                )
                .BuildSessionFactory();
        }
    }
}