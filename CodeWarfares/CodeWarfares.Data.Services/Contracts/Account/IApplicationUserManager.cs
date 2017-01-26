using CodeWarfares.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Services.Contracts.Account
{
    public interface IApplicationUserManager
    {
        bool CreateUser(IUser user, string password);
    }
}
