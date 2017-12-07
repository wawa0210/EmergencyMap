using Autofac;
using Autofac.Integration.WebApi;
using EmergencyAccount.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace EmergencyApi.App_Start
{
    public class AutofacWebApiConfig
    {
        public static void Run()
        {
            SetAutofacWebApi();
        }

        private static void SetAutofacWebApi()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            // Register API controllers using assembly scanning.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<AccountService>().As<IAccountService>()
                .InstancePerApiRequest();
            var container = builder.Build();
            // Set the WebApi dependency resolver.
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}