using Dao.HMS.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Model.HMS.Extensions;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Services.HMS.Helper
{
    public static class NhSessionFactory
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory GetSessionFactory()
        {
            return _sessionFactory ?? (_sessionFactory = Fluently.Configure().
                        Database(MsSqlConfiguration.MsSql2012.ConnectionString(DbConnectionString.MssqlConnectionString)
                           .ShowSql())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RoomregisterMap>())
                //.ExposeConfiguration(BuildSchema)
                .BuildSessionFactory());
        }

        private static void BuildSchema(NHibernate.Cfg.Configuration obj)
        {
            var se = new SchemaExport(obj);
            se.Execute(true, true, false);
        }

        public static ISession OpenSession()
        {
            return GetSessionFactory().OpenSession();
        }
    }
}