using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using CodeWarfares.Data.Models;
using CodeWarfares.Utils;
using CodeWarfares.Web.Views.Contracts.Account;
using CodeWarfares.Web.Presenters.Account.Contracts;
using Ninject;
using CodeWarfares.Data.Services.Account;
using CodeWarfares.Web.Presenters.Factories;

namespace CodeWarfares.Web.Account
{
    public partial class Login : Page, ILoginView
    {

        [Inject]
        public ILoginPresenterFactory LoginPresenterFactory { get; set; }

        public ILoginPresenter LoginPresenter { get; set; }

        public string Username
        {
            get
            {
                return this.UsernameTextBox.Text;
            }
            set
            {
                this.UsernameTextBox.Text = value;
            }
        }

        public string Password
        {
            get
            {
                return this.PasswordTextBox.Text;
            }
            set
            {
                this.PasswordTextBox.Text = value;
            }
        }

        public bool ShouldRemember
        {
            get
            {
                return this.RememberMe.Checked;
            }
            set
            {
                this.RememberMe.Checked = value;
            }
        }

        public bool AreFieldsValid
        {
            get
            {
                return this.IsValid;
            }
        }

        public string ErrorText
        {
            get
            {
                return this.FailureText.Text;
            }
            set
            {
                this.FailureText.Text = value;
            }
        }

        public bool ErrorTextVisible
        {
            get
            {
                return this.ErrorMessage.Visible;
            }
            set
            {
                this.ErrorMessage.Visible = value;
            }
        }

        public string RegisterNavigateUrl
        {
            get
            {
                return this.RegisterHyperLink.NavigateUrl;
            }
            set
            {
                this.RegisterHyperLink.NavigateUrl = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoginPresenter = this.LoginPresenterFactory.Create(this);

            this.LoginPresenter.Initialize();
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                var result = signinManager.PasswordSignIn(UsernameTextBox.Text, PasswordTextBox.Text, RememberMe.Checked, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }

        public void Success()
        {
            this.Response.Redirect("~/");
        }
    }
}