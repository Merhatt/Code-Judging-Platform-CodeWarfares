using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Services.Contracts.Account
{
    public interface IApplicationSignInManager
    {
        /// <summary>
        /// Sings in user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="isPersistent"></param>
        /// <param name="shouldLockout"></param>
        /// <returns></returns>
        bool SignIn(string userName, string password, bool isPersistent, bool shouldLockout = false);
    }
}
