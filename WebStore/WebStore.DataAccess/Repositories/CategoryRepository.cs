using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DataAccess.Context;
using WebStore.DataAccess.Repositories.Base;
using WebStore.Domain.Entities;
using System.Data.Entity;

namespace WebStore.DataAccess.Repositories
{
    public class CategoryRepository
        : ICategoryRepository
    {
        private WebStoreDbContext _context;

        public CategoryRepository(WebStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories
                .Include(x => x.ChildCategories)
                .Include(x => x.HeadCategory).ToArray();
        }
    }
}
