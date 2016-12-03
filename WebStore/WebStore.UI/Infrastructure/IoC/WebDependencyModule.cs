using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Module = Autofac.Module;

namespace WebStore.UI.Infrastructure.IoC
{
    public class WebDependencyModule
        : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();

            builder.Register(ctn => AutoMapperConfig.GetConfiguration()).SingleInstance();
            builder.Register(ctn => ctn.Resolve<MapperConfiguration>().CreateMapper()).SingleInstance();
        }
    }
}