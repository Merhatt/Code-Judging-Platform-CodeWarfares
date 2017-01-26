using CodeWarfares.Data.Models.Contracts;
using CodeWarfares.Data.Models.Factories;
using CodeWarfares.Data.Services.Contracts.Account;
using CodeWarfares.Web.Presenters.Contracts.Account;
using CodeWarfares.Web.Views.Contracts.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.Presenters.Account
{
    public class RegisterPresenter : Presenter<IRegisterView>, IRegisterPresenter
    {
        private IUserFactory userFactory;

        public RegisterPresenter(IRegisterView view, IUserFactory userFactory) : base(view)
        {
            this.userFactory = userFactory;
        }

        public void Register()
        {
            IApplicationUserManager userManager = this.View.UserManager;
            IApplicationSignInManager signInManager = this.View.SignInManager;
            IUser user = this.userFactory.Create();
            user.UserName = this.View.Username;
            user.Email = this.View.Email;
            bool isCreated = userManager.CreateUser(user, this.View.Password);
            if (isCreated)
            {
                signInManager.SignIn(user.UserName, this.View.Password, false);
                this.View.Success();
            }
            else
            {
                this.View.ErrorText = "Cannot register";
            }
        }
    }
}