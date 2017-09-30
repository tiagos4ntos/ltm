using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using System;
using System.IO;
using System.Reflection;

namespace LTM.Infra.Data.NH
{
    public static class NhSessionFactory
    {
        private static readonly ISessionFactory _sessionFactory;

        static NhSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008
                        .ConnectionString(
                            builder => builder.FromConnectionStringWithKey("ltm_connectionstring")))
                    .Mappings(x =>
                    {
                        x.FluentMappings.Conventions.Setup(y => y.Add(AutoImport.Never()));

                        var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                        var uri = new UriBuilder(codeBase);
                        var path = Uri.UnescapeDataString(uri.Path);
                        var dirName = Path.GetDirectoryName(path) ?? string.Empty;
                        string[] dlls = Directory.GetFiles(dirName, "*Infra*.dll");
                        foreach (var dll in dlls)
                        {
                            var assembly = Assembly.LoadFrom(dll);
                            x.FluentMappings.AddFromAssembly(assembly);
                        }
                    })
                    .ExposeConfiguration(c => c.SetProperty("command_timeout", TimeSpan.FromMinutes(5).TotalSeconds.ToString()))
                    .BuildSessionFactory();
        }

        public static ISessionFactory Current
        {
            get
            {
                return _sessionFactory;
            }
        }
    }
}
