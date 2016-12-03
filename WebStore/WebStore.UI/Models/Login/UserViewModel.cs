using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.UI.Models.Login
{
    public class UserViewModel
    {
        public bool IsAuthenticaticated { get; set; }
        public string Login { get; set; }
    }
}