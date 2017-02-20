using System;
using CodeWarfares.Data.Services.Contracts.Account;
using CodeWarfares.Data.Services.Enums;
using CodeWarfares.Web.Presenters.Account.Contracts;
using CodeWarfares.Web.Views.Contracts.Account;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using CodeWarfares.Data.Models;
using System.Linq;
using System.Threading.Tasks;
using WebFormsMvp;
using CodeWarfares.Web.EventArguments;

namespace CodeWarfares.Web.Presenters.Account
{
    public class LoginPresenter : Presenter<ILoginView>, ILoginPresenter
    {
        public LoginPresenter(ILoginView view) : base(view)
        {
            view.MyInit += Initialize;
            view.SignInEvent += SignIn;
        }

        private void Initialize(object obj, EventArgs e)
        {
            this.View.Model.RegisterNavigateUrl = "Register";
        }

        private void SignIn(object sender, SignInEventArgs e)
        {
            if (e.AreFieldsValid)
            {
                IApplicationSignInManager signinManager = e.SignInManager;
 
                bool isSignedIn = signinManager.SignIn(e.Username, e.Password, e.ShouldRemember);

                if (isSignedIn)
                {
                    this.View.Model.IsSignedIn = true;
                }
                else
                {
                    this.View.Model.ErrorText = "Invalid login attempt";
                    this.View.Model.ErrorTextVisible = true;
                }
            }
        }
    }
}
