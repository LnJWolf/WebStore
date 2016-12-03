using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DataAccess.Context;
using WebStore.Domain.Entities;

namespace WebStore.DataAccess.Initializers
{
    public class WebStoreContextInitializer
        : CreateDatabaseIfNotExists<WebStoreDbContext>
    {
        protected override void Seed(WebStoreDbContext context)
        {
            context.Categories.AddRange(new List<Category>
            {
                new Category { Name = "Продукты" , Id = 1 }
            });

            context.SaveChanges();

            context.Products.AddRange(new List<Product>
            {
                new Product { Name = "Кефир", CategoryId = 1, Description = "Кифир домик в деревне", Price = 63, Category = context.Categories.Single(x => x.Id == 1)},
                new Product { Name = "Молоко", CategoryId = 1, Description = "Кифир домик в деревне", Price = 111, Category = context.Categories.Single(x => x.Id == 1) },
                new Product { Name = "Йогурт", CategoryId = 1, Description = "Кифир домик в деревне", Price = 33, Category = context.Categories.Single(x => x.Id == 1) },
                new Product { Name = "Сок", CategoryId = 1, Description = "Кифир домик в деревне", Price = 222, Category = context.Categories.Single(x => x.Id == 1) },
                new Product { Name = "Шоколад", CategoryId = 1, Description = "Кифир домик в деревне", Price = 33, Category = context.Categories.Single(x => x.Id == 1) }
            });

            context.SaveChanges();

            context.Roles.AddRange(new List<Role> {
                new Role {  Name = "Гость" },
                new Role {  Name = "Пользователь" },
                new Role {  Name = "Администратор" },
            });

            context.SaveChanges();

            context.Groups.AddRange(new List<Group> {
                new Group {  Name = "Гости", Roles = context.Roles.Where(x => x.Id == 1).ToList() },
                new Group {  Name = "Пользователи", Roles = context.Roles.Where(x => x.Id == 2).ToList() },
                new Group {  Name = "Администраторы", Roles = context.Roles.Where(x => x.Id == 3).ToList() },
            });

            context.SaveChanges();

            var random = new Random(1);

            context.Users.AddRange(new List<User> {
                new User {
                    Id = 1,
                    Login = "admin",
                    GroupId = 3,
                    Password = Convert.ToBase64String(Encoding.UTF8.GetBytes("admin1")),
                    DateCreated = DateTime.Now,
                    DateOfBirth = DateTime.Now.AddDays(random.Next(-100, 100)),
                    PassportNumber = 1111,
                    PassportSerie = 2222,
                    Name = new string(Path.GetRandomFileName().Take(4).ToArray()),
                    Patronymic = new string(Path.GetRandomFileName().Take(4).ToArray()),
                    Surname  = new string(Path.GetRandomFileName().Take(4).ToArray())
                },
                new User {
                    Id = 2,
                    Login = "user",
                    GroupId = 2,
                    Password = Convert.ToBase64String(Encoding.UTF8.GetBytes("user1")),
                    DateCreated = DateTime.Now,
                    DateOfBirth = DateTime.Now.AddDays(random.Next(-100, 100)),
                    PassportNumber = 1111,
                    PassportSerie = 2222,
                    Name = new string(Path.GetRandomFileName().Take(4).ToArray()),
                    Patronymic = new string(Path.GetRandomFileName().Take(4).ToArray()),
                    Surname  = new string(Path.GetRandomFileName().Take(4).ToArray())
                },
                new User {
                    Id = 3,
                    Login = "guest",
                    GroupId = 1,
                    Password = Convert.ToBase64String(Encoding.UTF8.GetBytes("guest1")),
                    DateCreated = DateTime.Now,
                    DateOfBirth = DateTime.Now.AddDays(random.Next(-100, 100)),
                    PassportNumber = 1111,
                    PassportSerie = 2222,
                    Name = new string(Path.GetRandomFileName().Take(4).ToArray()),
                    Patronymic = new string(Path.GetRandomFileName().Take(4).ToArray()),
                    Surname  = new string(Path.GetRandomFileName().Take(4).ToArray())
                }
            });

            context.SaveChanges();
        }
    }
}