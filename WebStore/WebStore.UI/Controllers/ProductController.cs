using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.BusinessLogic.DTO;
using WebStore.BusinessLogic.Services.Base;

namespace WebStore.UI.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        IProductService _productService = null;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult ProductFilter()
        {
            return PartialView("_ProductFilter");
        }

        public ActionResult Products(ProductFilter filter = null)
        {
            var products = _productService.GetProducts(filter);

            return PartialView("_ProductList", products);
        }
    }
}