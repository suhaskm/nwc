using log4net;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.WebApi;

namespace NWC.Business.Layer
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<INumberData, NumberData>();
            container.RegisterType<ILog>(new InjectionFactory(factory => LogManager.GetLogger("RollingFile")));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}