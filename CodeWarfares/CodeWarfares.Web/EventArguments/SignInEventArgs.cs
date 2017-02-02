using CodeWarfares.Data.Services.Contracts.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.EventArguments
{
    public class SignInEventArgs : EventArgs
    {
        public SignInEventArgs(bool areFieldsValid, IApplicationSignInManager signInManager, string username, string password, bool shouldRemember)
        {
            this.AreFieldsValid = areFieldsValid;
            this.SignInManager = signInManager;
            this.Username = username;
            this.Password = password;
            this.ShouldRemember = shouldRemember;
        }

        public bool AreFieldsValid { get; private set; }

        public IApplicationSignInManager SignInManager { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public bool ShouldRemember { get; private set; }
    }
}