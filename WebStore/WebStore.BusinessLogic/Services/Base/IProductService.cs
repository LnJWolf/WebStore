using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebStore.BusinessLogic.DTO;
using WebStore.BusinessLogic.DTO.Product;
using WebStore.Domain.Entities;

namespace WebStore.BusinessLogic.Services.Base
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(ProductFilter filter = null);
        IEnumerable<Product/*ViewModel*/> GetProductsByIDs(IEnumerable<int> IDs);
        ProductViewModel GetProduct(int id);
        IEnumerable<SelectListItem> GetCategories();

        void UpdateProduct(ProductViewModel viewModel);

        void RemoveProduct(int id);
    }
}
