using CodeWarfares.Data.Services.Contracts.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Web.Views.Contracts.Account
{
    public interface IRegisterView : IView
    {
        IApplicationSignInManager SignInManager { get; }

        IApplicationUserManager UserManager { get; }

        string Username { get; set; }

        string Password { get; set; }

        string Email { get; set; }

        string ErrorText { get; set; }

        void Success();
    }
}
