using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebStore.UI.Models.Login
{
    public class UserLoginViewModel
    {
        [DisplayName("Логин")]
        public string Login { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}