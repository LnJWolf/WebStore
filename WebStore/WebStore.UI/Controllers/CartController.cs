using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.UI.Models.Cart;
using WebStore.BusinessLogic.Services.Base;

namespace WebStore.UI.Controllers
{
    public class CartController : Controller
    {
        private const string cookieName = "cart";
        IProductService _productServ = null;

        public CartController(IProductService productServ)
        {
            _productServ = productServ;
        }

        public ActionResult CurrentCart()
        {
            CartViewModel cart = ReadingCookie(false);

            return PartialView("_CurrentCart", cart);
        }

        public ActionResult CurrentCartList()
        {
            CartViewModel cart = ReadingCookie(false);

            var arrayOfID = cart.Items.Select(x => x.ProductId);
            var shownProducts = _productServ.GetProductsByIDs(arrayOfID).ToArray();

            var ArrayOfQuantities = cart.Items.Select(x => x.Quantity).ToArray();
            ViewBag.Quantities = ArrayOfQuantities;

            List<double> combinedPrice4Product = new List<double>();
            double total = 0;
            double between = 0;
            for (int i = 0; i < shownProducts.Length; i++)
            {
                between = shownProducts[i].Price * ArrayOfQuantities[i];
                combinedPrice4Product.Add(between);
                total += between;
            }
            ViewBag.cP4P = combinedPrice4Product.ToArray();
            ViewBag.total = total;

            return View(shownProducts);
        }

        public ActionResult AddToCart(int id, bool IsIndex)
        {
            CartViewModel cart = ReadingCookie(true);

            if(cart.Items == null)
                cart.Items = new List<CartItem>();

            var product = cart.Items.FirstOrDefault(x => x.ProductId == id);

            if (product == null)
                cart.Items.Add(new CartItem { ProductId = id, Quantity = 1 });
            else
                product.Quantity++;

            RewritingCookie(cart);

            if (IsIndex)
            {
                return RedirectToAction("Index", "Main");
            }

            return RedirectToAction("CurrentCartList");
        }

        public ActionResult RemoveFromCart(int id)
        {
            CartViewModel cart = ReadingCookie(false);

            if (cart.Items == null)
                cart.Items = new List<CartItem>();

            var product = cart.Items.FirstOrDefault(x => x.ProductId == id);

            if (product == null)
                return HttpNotFound();
            else if (product.Quantity>1)
                product.Quantity--;
            else
            {
                cart.Items.Remove(product);
            }

            RewritingCookie(cart);

            return RedirectToAction("CurrentCartList");
        }

        private CartViewModel ReadingCookie(bool addDay)
        {
            var cookie = Request.Cookies.Get(cookieName);
            CartViewModel cart = null;

            if (cookie == null)
            {
                cart = new CartViewModel();
                cookie = new HttpCookie(cookieName);
            }
            else
            {
                var cartValue = cookie.Values.Get("cart");

                if (string.IsNullOrWhiteSpace(cartValue))
                    cart = new CartViewModel();
                else
                    cart = Newtonsoft.Json.JsonConvert.DeserializeObject<CartViewModel>(cartValue);
            }

            if (addDay) cookie.Expires = DateTime.Now.AddDays(1);

            return cart;
        }

        private void RewritingCookie(CartViewModel cart4Cook)
        {
            var cookie = Request.Cookies.Get(cookieName);

            cookie.Values.Clear();

            cookie.Values.Add("cart", Newtonsoft.Json.JsonConvert.SerializeObject(cart4Cook));

            Response.Cookies.Add(cookie);
        }
    }
}