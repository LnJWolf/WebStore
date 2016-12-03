using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.BusinessLogic.Services.Base;
using WebStore.DataAccess.Repositories.Base;

namespace WebStore.BusinessLogic.Services
{
    public class AuthenticationService
        : IAuthenticationService
    {
        private IAuthenticationRepository _authenticationRepository;

        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public bool Authenticaticate(string login, string password)
        {
            string passwordBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));

            var user = _authenticationRepository.FindUserByLogin(login);

            if (user == null)
                return false;

            return user.Password == passwordBase64;
        }

        public bool IsInRole(string login, string roleName)
        {
            var user = _authenticationRepository.FindUserByLogin(login);

            if (user == null)
                return false;

            return user.Group.Roles.Any(x => x.Name == roleName);
        }
    }
}