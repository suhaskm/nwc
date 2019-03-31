using System.Web.Mvc;
using log4net;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace NWC.App.Layer
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ILog>(new InjectionFactory(factory => LogManager.GetLogger("RollingFile")));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}