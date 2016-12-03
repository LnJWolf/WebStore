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

            return PartialView("_CurrentCart", cart);
        }

        public ActionResult CurrentCartList()
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
            var arrayOfID = cart.Items.Select(x => x.ProductId);
            var shownProducts = _productServ.GetProductsByIDs(arrayOfID).ToArray();

            var ArrayOfQuantities = cart.Items.Select(x => x.Quantity).ToArray();
            ViewBag.Quantities = ArrayOfQuantities;

            return View(shownProducts);
        }

        public ActionResult AddToCart(int id, bool IsIndex)
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

                if(string.IsNullOrWhiteSpace(cartValue))
                    cart = new CartViewModel();
                else
                    cart = Newtonsoft.Json.JsonConvert.DeserializeObject<CartViewModel>(cartValue);
            }

            cookie.Expires = DateTime.Now.AddDays(1);

            if(cart.Items == null)
                cart.Items = new List<CartItem>();

            var product = cart.Items.FirstOrDefault(x => x.ProductId == id);

            if (product == null)
                cart.Items.Add(new CartItem { ProductId = id, Quantity = 1 });
            else
                product.Quantity++;
            
            cookie.Values.Clear();

            cookie.Values.Add("cart", Newtonsoft.Json.JsonConvert.SerializeObject(cart));

            Response.Cookies.Add(cookie);

            if (IsIndex)
            {
                return RedirectToAction("Index", "Main");
            }

            return RedirectToAction("CurrentCartList");
        }

        public ActionResult RemoveFromCart(int id)
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

            cookie.Expires = DateTime.Now.AddDays(1);

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

            cookie.Values.Clear();

            cookie.Values.Add("cart", Newtonsoft.Json.JsonConvert.SerializeObject(cart));

            Response.Cookies.Add(cookie);

            return RedirectToAction("CurrentCartList");
        }
    }
}