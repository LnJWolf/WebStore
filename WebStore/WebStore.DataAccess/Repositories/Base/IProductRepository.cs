using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebStore.Domain.Entities;

namespace WebStore.DataAccess.Repositories.Base
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProducts(Expression<Func<Product, bool>> func);

        Product GetProduct(int id);
        Product GetProductWithCategory(int id);
        Product GetProduct(Expression<Func<Product, bool>> func);

        IQueryable<Product> GetProductsAsQueryable();
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        
        void SaveChanges();
    }
}