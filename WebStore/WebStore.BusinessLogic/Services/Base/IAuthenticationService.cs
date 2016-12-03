using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.BusinessLogic.Services.Base
{
    public interface IAuthenticationService
    {
        bool Authenticaticate(string login, string password);
        bool IsInRole(string login, string roleName);
    }
}