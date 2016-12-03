using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DataAccess.Context;
using WebStore.DataAccess.Repositories.Base;
using WebStore.Domain.Entities;
using System.Data.Entity;

namespace WebStore.DataAccess.Repositories
{
    public class AuthenticationRepository
        : IAuthenticationRepository
    {
        private WebStoreDbContext _context;

        public AuthenticationRepository(WebStoreDbContext context)
        {
            _context = context;
        }

        public User FindUserByLogin(string login)
        {
            return _context.Users
                            .Include(x => x.Group)
                            .Include(x => x.Group.Roles)
                            .FirstOrDefault(x => x.Login == login);
        }
    }
}