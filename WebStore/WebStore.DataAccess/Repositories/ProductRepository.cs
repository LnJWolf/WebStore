using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebStore.DataAccess.Context;
using WebStore.DataAccess.Repositories.Base;
using WebStore.Domain.Entities;
using System.Data.Entity;

namespace WebStore.DataAccess.Repositories
{
    public class ProductRepository
        : IProductRepository
    {
        WebStoreDbContext _context = null;

        public ProductRepository(WebStoreDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product GetProduct(int id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }

        public Product GetProductWithCategory(int id)
        {
            return _context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }


        public Product GetProduct(Expression<Func<Product, bool>> func)
        {
            return _context.Products.FirstOrDefault(func);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.Include(x => x.Category).ToArray();
        }

        public IEnumerable<Product> GetProducts(Expression<Func<Product, bool>> func)
        {
            return _context.Products.Include(x => x.Category).Where(func).ToArray();
        }

        public IQueryable<Product> GetProductsAsQueryable()
        {
            return _context.Products.Include(x => x.Category);
        }

        public void RemoveProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}