using CodeWarfares.Data.Services.Contracts.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.EventArguments
{
    public class RegisterEventArgs : EventArgs
    {
        public RegisterEventArgs(IApplicationUserManager userManager, IApplicationSignInManager signInManager, string username, string email, string password)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
            this.Username = username;
            this.Password = password;
            this.Email = email;
        }

        public IApplicationSignInManager SignInManager { get; private set; }

        public IApplicationUserManager UserManager { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public string Email { get; private set; }
    }
}