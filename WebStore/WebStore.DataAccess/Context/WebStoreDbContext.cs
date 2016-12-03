using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.Entities;

namespace WebStore.DataAccess.Context
{
    public class WebStoreDbContext
        : DbContext
    {
        public WebStoreDbContext()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new GroupEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new RoleEntityTypeConfiguration());
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
