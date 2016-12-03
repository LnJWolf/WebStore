using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Security;
using WebStore.BusinessLogic.Services.Base;
using WebStore.UI.Models.Login;

namespace WebStore.UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private IAuthenticationService _authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet]
        public ActionResult UserLogin()
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
                return PartialView("_UserLogin", new UserViewModel { IsAuthenticaticated = true, Login = Thread.CurrentPrincipal.Identity.Name });

            return PartialView("_UserLogin");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            if (_authenticationService.Authenticaticate(viewModel.Login, viewModel.Password))
            {
                FormsAuthentication.SetAuthCookie(viewModel.Login, true);

                return Redirect(FormsAuthentication.DefaultUrl);
            }

            return View(viewModel);
        }
    }
}