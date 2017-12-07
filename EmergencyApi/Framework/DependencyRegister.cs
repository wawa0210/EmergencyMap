using Autofac;
using Autofac.Integration.WebApi;
using EmergencyAccount.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace EmergencyApi.Framework
{
    public class DependencyRegister
    {
        public static void Register(HttpConfiguration config)
        {
            //var builder = new ContainerBuilder();

            //builder.RegisterAssemblyTypes(typeof(IAccountService).Assembly)
            //  .AsImplementedInterfaces();

            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //var container = builder.Build();
            //var resolver = new AutofacWebApiDependencyResolver(container);
            //config.DependencyResolver = resolver;
        }
    }
}