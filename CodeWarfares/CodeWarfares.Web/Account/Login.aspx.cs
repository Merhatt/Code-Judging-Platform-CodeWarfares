using System;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using CodeWarfares.Web.Views.Contracts.Account;
using CodeWarfares.Data.Services.Account;
using WebFormsMvp.Web;
using CodeWarfares.Web.Views.Models;
using CodeWarfares.Web.EventArguments;
using WebFormsMvp;
using CodeWarfares.Web.Presenters.Account;

namespace CodeWarfares.Web.Account
{
    [PresenterBinding(typeof(LoginPresenter))]
    public partial class Login : MvpPage<LoginViewModel>, ILoginView
    {
        public event EventHandler MyInit;

        public event EventHandler<SignInEventArgs> SignInEvent;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.MyInit(sender, e);

            this.RegisterHyperLink.NavigateUrl = this.Model.RegisterNavigateUrl;
        }

        protected void LogIn(object sender, EventArgs e)
        {
            SignInEventArgs args = new SignInEventArgs(this.IsValid,
                                                  this.Context.GetOwinContext().GetUserManager<ApplicationSignInManager>(),
                                                  this.UsernameTextBox.Text,
                                                  this.PasswordTextBox.Text,
                                                  this.RememberMe.Checked);

            this.SignInEvent?.Invoke(sender, args);

            this.FailureText.Text = this.Model.ErrorText;
            this.ErrorMessage.Visible = this.Model.ErrorTextVisible;

            if (this.Model.IsSignedIn)
            {
                this.Response.Redirect("~/");
            }
        }
    }
}