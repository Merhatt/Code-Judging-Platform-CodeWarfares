using CodeWarfares.Data.Services.Contracts.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeWarfares.Data.Services.Enums;
using CodeWarfares.Web;
using CodeWarfares.Web.AppStart.Contracts;

namespace CodeWarfares.Data.Services.Account
{
    public class UserServices : IUserServices
    {
        private readonly IApplicationSignInManager signInManager;

        public UserServices(IApplicationSignInManager signInManager)
        {
            this.signInManager = signInManager;
        }

        public LoginType PasswordSignIn(string username, string password, bool remember, bool shouldLockout = false)
        {
            var result = this.signInManager.SignIn(username, password, remember, shouldLockout);

            if (result)
            {
                return LoginType.Success;
            }
            else
            {
                return LoginType.Failure;
            }
        }
    }
}
