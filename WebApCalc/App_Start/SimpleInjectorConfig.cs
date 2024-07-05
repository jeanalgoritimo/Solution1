using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.WebApi;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApCalc.Interface;
using WebApCalc.Services;

namespace ApiTeste.App_Start
{
    public class SimpleInjectorConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

         
            container.Register<ICalcular, Calcular>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(config);
            container.Verify(VerificationOption.VerifyOnly);

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

        }
    }
}