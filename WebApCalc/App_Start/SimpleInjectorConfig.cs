using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.WebApi;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApi.Calculo.Aplication.Interfaces;
using WebApi.Calculo.Aplication.Services;

namespace ApiTeste.App_Start
{
    public class SimpleInjectorConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

         
            container.Register<ICalcularService, CalcularService>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(config);
            container.Verify(VerificationOption.VerifyOnly);

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

        }
    }
}