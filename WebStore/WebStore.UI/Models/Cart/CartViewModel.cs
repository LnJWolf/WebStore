using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.UI.Models.Cart
{
    public class CartViewModel
    {
        public List<CartItem> Items { get; set; } = null;

        public bool IsNull() => Items == null;
    }
}