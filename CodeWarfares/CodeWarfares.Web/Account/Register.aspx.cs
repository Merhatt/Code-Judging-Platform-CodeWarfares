using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using CodeWarfares.Utils;
using CodeWarfares.Data.Models;
using CodeWarfares.Data.Services.Account;
using CodeWarfares.Web.Views.Contracts.Account;
using CodeWarfares.Data.Services.Contracts.Account;
using CodeWarfares.Web.Presenters.Factories;
using CodeWarfares.Web.Presenters.Contracts.Account;
using Ninject;

namespace CodeWarfares.Web.Account
{
    public partial class Register : Page, IRegisterView
    {
        [Inject]
        public IRegisterPresenterFactory PresenterFactory { get; set; }

        public IRegisterPresenter RegisterPresenter { get; set; }

        public string ErrorText
        {
            get
            {
                return this.ErrorMessage.Text;
            }

            set
            {
                this.ErrorMessage.Text = value;
            }
        }

        public IApplicationSignInManager SignInManager
        {
            get
            {
                return Context.GetOwinContext().Get<ApplicationSignInManager>();
            }
        }

        public IApplicationUserManager UserManager
        {
            get
            {
                return this.Context.GetOwinContext().Get<ApplicationUserManager>();
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

        public string Email
        {
            get
            {
                return this.EmailTextBox.Text;
            }
            set
            {
                this.EmailTextBox.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.RegisterPresenter = this.PresenterFactory.Create(this);
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            this.RegisterPresenter.Register();
        }

        public void Success()
        {
            this.Response.Redirect("~/");
        }
    }
}