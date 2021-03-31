using FluentValidation.Mvc;
using FrameworkWorkShop.Core.CrossCuttingConcerns.Validation.FluentValidation;
using FrameworkWorkShop.Core.Utilities.Mvc.Infrastructer;
using MemberRegistration.Business.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MemberRegistration.MvcUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));
            FluentValidationModelValidatorProvider.Configure(provider => {
                provider.ValidatorFactory = new NinjectValidationFactory(new ValidationModule());
            });
        }
    }
}
