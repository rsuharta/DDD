namespace Infrastructure.DbContext
{
    using Domain;

    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;

    public class InMemorySessionFactoryProvider
    {
        private static InMemorySessionFactoryProvider instance;
        public static InMemorySessionFactoryProvider Instance => instance ?? (instance = new InMemorySessionFactoryProvider());

        private ISessionFactory sessionFactory;
        private Configuration configuration;
        private ISession session;

        private InMemorySessionFactoryProvider() { }

        public void Initialize()
        {
            this.sessionFactory = this.CreateSessionFactory();
        }

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StudentMap>())
                .ExposeConfiguration(cfg => this.configuration = cfg)
                .BuildSessionFactory();
        }

        public ISession DbSession()
        {
            if (this.session == null || !this.session.IsOpen)
            {
                this.OpenSession();
            }

            return this.session;
        }

        private void OpenSession()
        {
            this.session = this.sessionFactory.OpenSession();

            var export = new SchemaExport(this.configuration);
            export.Execute(true, true, false, this.session.Connection, null);
        }

        public void Dispose()
        {
            if (this.sessionFactory != null)
                this.sessionFactory.Dispose();

            this.sessionFactory = null;
            this.configuration = null;
        }
    }
}
