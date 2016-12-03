using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.Entities;

namespace WebStore.DataAccess.Repositories.Base
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
    }
}