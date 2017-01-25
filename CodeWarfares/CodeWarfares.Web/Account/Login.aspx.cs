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

namespace CodeWarfares.Web.Account
{
    public partial class Login : Page, ILoginView
    {
        [Inject]
        private ILoginPresenter loginPresenter;

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
            this.loginPresenter.Initialize();
        }

        protected void LogIn(object sender, EventArgs e)
        {
            this.loginPresenter.SignIn();
        }

        public void Success()
        {
            this.Response.Redirect("~/");
        }
    }
}