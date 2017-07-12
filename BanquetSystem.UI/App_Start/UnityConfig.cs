using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using BanquetSystem.Business;

namespace BanquetSystem.UI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            //container.RegisterType<IUnitOfWork, UnitOfWork>();
            //container.RegisterType<ICustomerServices, CustomerServices>();
            //container.RegisterType<ICustomerDetailServices, CustomerDetailServices>();
            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}