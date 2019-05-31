using Cinema.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.DAL.Interfaces
{
    public interface IApplicationUserRepository
    {
        ApplicationUser GetByEmail(string email);

        ApplicationUser GetByUserName(string name);

        bool IsExists(string email);

        List<ApplicationUser> Find(Func<ApplicationUser, Boolean> predicate);

        void Create();
    }
}
