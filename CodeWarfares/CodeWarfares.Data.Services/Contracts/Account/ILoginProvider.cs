using CodeWarfares.Data.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Services.Contracts.Account
{
    public interface ILoginProvider
    {
        LoginType PasswordSignIn(string username, string password, bool remember, bool shouldLockout = false);
    }
}
