using System;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using CodeWarfares.Data.Services.Account;
using CodeWarfares.Web.Views.Contracts.Account;
using Ninject;
using WebFormsMvp.Web;
using CodeWarfares.Web.Views.Models;
using CodeWarfares.Web.EventArguments;
using WebFormsMvp;
using CodeWarfares.Web.Presenters.Account;

namespace CodeWarfares.Web.Account
{
    [PresenterBinding(typeof(RegisterPresenter))]
    public partial class Register : MvpPage<RegisterViewModel>, IRegisterView
    {
        public event EventHandler<RegisterEventArgs> RegisterEvent;

        public Register()
        {

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            RegisterEventArgs args = new RegisterEventArgs(this.Context.GetOwinContext().Get<ApplicationUserManager>(),
                                            Context.GetOwinContext().Get<ApplicationSignInManager>(),
                                            this.UsernameTextBox.Text,
                                            this.EmailTextBox.Text,
                                            this.PasswordTextBox.Text);

            this.RegisterEvent?.Invoke(sender, args);

            this.ErrorMessage.Text = this.Model.ErrorText;

            if (this.Model.Success)
            {
                this.Response.Redirect("~/");
            }
        }
    }
}