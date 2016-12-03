using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebStore.BusinessLogic.DTO;
using WebStore.BusinessLogic.DTO.Product;
using WebStore.BusinessLogic.Services.Base;

namespace WebStore.UI.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        IProductService _productService = null;

        public MainController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.IsEdit = true;
            ViewBag.Categories = _productService.GetCategories();

            var prod = _productService.GetProduct(id);

            return View("Product", prod);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel viewModel)
        {
            ViewBag.IsEdit = true;

            if (!ModelState.IsValid)
                return View("Product", viewModel);

            _productService.UpdateProduct(viewModel);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = _productService.GetCategories();

            return View("Product");
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("Product", viewModel);

            _productService.UpdateProduct(viewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Remove(int id)
        {
            _productService.RemoveProduct(id);

            return RedirectToAction("Index");
        }
    }
}