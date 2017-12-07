using Autofac;
using Autofac.Integration.WebApi;
using EmergencyAccount.Application;
using EmergencyAccount.Data;
using EmergencyApi.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace EmergencyApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MapperInit.InitMapping();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
