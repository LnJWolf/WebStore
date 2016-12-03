using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using WebStore.BusinessLogic;
using WebStore.DataAccess;
using WebStore.UI.Infrastructure.IoC;

namespace WebStore.UI.Infrastructure
{
    public static class DependencyConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<WebDependencyModule>();
            builder.RegisterModule<DataAccessDependencyModule>();
            builder.RegisterModule<BusinessLogicDependencyModule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}