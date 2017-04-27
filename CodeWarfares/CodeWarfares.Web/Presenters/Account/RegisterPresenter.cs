using CodeWarfares.Data.Models.Contracts;
using CodeWarfares.Data.Models.Factories;
using CodeWarfares.Data.Services.Contracts.Account;
using CodeWarfares.Web.EventArguments;
using CodeWarfares.Web.Presenters.Contracts.Account;
using CodeWarfares.Web.Views.Contracts.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace CodeWarfares.Web.Presenters.Account
{
    /// <summary>
    /// Presenter for Register Page
    /// </summary>
    public class RegisterPresenter : Presenter<IRegisterView>, IRegisterPresenter
    {
        private IUserFactory userFactory;

        public RegisterPresenter(IRegisterView view, IUserFactory userFactory) : base(view)
        {
            if (userFactory == null)
            {
                throw new NullReferenceException("userFactory cannot be null");
            }

            this.userFactory = userFactory;
            view.RegisterEvent += Register;
        }

        private void Register(object sender, RegisterEventArgs e)
        {
            IApplicationUserManager userManager = e.UserManager;
            IApplicationSignInManager signInManager = e.SignInManager;
            IUser user = this.userFactory.Create();
            user.UserName = e.Username;
            user.Email = e.Email;
            bool isCreated = userManager.CreateUser(user, e.Password);

            if (isCreated)
            {
                signInManager.SignIn(user.UserName, e.Password, false);
                this.View.Model.Success = true;
            }
            else
            {
                this.View.Model.ErrorText = "Cannot register";
            }
        }
    }
}