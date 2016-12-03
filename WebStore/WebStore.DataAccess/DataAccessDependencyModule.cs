using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using WebStore.DataAccess.Context;
using WebStore.DataAccess.Repositories;
using WebStore.DataAccess.Repositories.Base;

namespace WebStore.DataAccess
{
    public class DataAccessDependencyModule
        : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WebStoreDbContext>()
                .Named<DbContext>("DataContext")
                .InstancePerRequest();

            builder.RegisterType(typeof(ProductRepository)).As(typeof(IProductRepository))
                .WithParameter((pi, c) => pi.Name == "context",
                   (pi, c) => (WebStoreDbContext)c.ResolveNamed<DbContext>("DataContext"))
                .InstancePerRequest();

            builder.RegisterType(typeof(CategoryRepository)).As(typeof(ICategoryRepository))
                .WithParameter((pi, c) => pi.Name == "context",
                   (pi, c) => (WebStoreDbContext)c.ResolveNamed<DbContext>("DataContext"))
                .InstancePerRequest();

            builder.RegisterType(typeof(AuthenticationRepository)).As(typeof(IAuthenticationRepository))
                .WithParameter((pi, c) => pi.Name == "context",
                   (pi, c) => (WebStoreDbContext)c.ResolveNamed<DbContext>("DataContext"))
                .InstancePerRequest();
        }
    }
}