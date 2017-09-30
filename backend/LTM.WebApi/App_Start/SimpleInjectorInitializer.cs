using AutoMapper;
using LTM.Application.AutoMapperProfile;
using LTM.Application.ServiceDomain;
using LTM.Application.ServiceDomain.Impl;
using LTM.Core.Domain;
using LTM.Core.Domain.Repositories;
using LTM.Core.Infra.Repositories;
using LTM.Infra.Data.Core;
using LTM.Infra.Data.NH;
using LTM.WebApi.MapperProfile;
using NHibernate;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;

namespace LTM.WebApi.App_Start
{
    public class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = Bootstrapper.Container;
            RegisterTypes(container);
            RegisterServices(container);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void RegisterTypes(Container container)
        {            
            container.Register(() => NhSessionFactory.Current.OpenSession(), new AsyncScopedLifestyle());
            
            container.Register<INHSession>(() => new NHSession(container.GetInstance<ISession>()));
            container.Register(typeof(IRepository<>), typeof(Repository<>));            
            container.Register(typeof(INHUnitOfWorkFactory), typeof(DefaultUnitOfWorkFactory));
 
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AppProfile>();
                cfg.AddProfile<WebApiProfile>();     
            });

            container.RegisterSingleton(config);
            container.Register(() => config.CreateMapper(container.GetInstance));
        }

        private static void RegisterServices(Container container)
        {
            container.Register<IUserProfileService, UserProfileService>();
            container.Register<IProductService, ProductService>();            
        }
    }
}