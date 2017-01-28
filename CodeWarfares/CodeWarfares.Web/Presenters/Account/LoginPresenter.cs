using System;
using CodeWarfares.Data.Services.Contracts.Account;
using CodeWarfares.Data.Services.Enums;
using CodeWarfares.Web.Presenters.Account.Contracts;
using CodeWarfares.Web.Views.Contracts.Account;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using CodeWarfares.Data.Models;
using System.Linq;

namespace CodeWarfares.Web.Presenters.Account
{
    public class LoginPresenter : Presenter<ILoginView>, ILoginPresenter
    {
        public LoginPresenter(ILoginView view, ICodeSubmitionService codeTestingService, IProblemService problemService, IUserServices users) : base(view)
        {
            var problem = problemService.GetAll().First();

            codeTestingService.SendSubmition(users.GetAll().First(), problem, "using System; using System.Collections.Generic; using System.Linq; public class Program { public static void Main() { string input = Console.ReadLine(); Console.WriteLine(input); } }", ContestLaungagesTypes.CSharp);
        }

        public void Initialize()
        {
            this.View.RegisterNavigateUrl = "Register";
        }

        public void SignIn()
        {
            if (this.View.AreFieldsValid)
            {
                // Validate the user password;
                IApplicationSignInManager signinManager = this.View.SignInManager;

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                bool isSignedIn = signinManager.SignIn(this.View.Username, this.View.Password, this.View.ShouldRemember);

                if (isSignedIn)
                {
                    this.View.Success();
                }
                else
                {
                    this.View.ErrorText = "Invalid login attempt";
                    this.View.ErrorTextVisible = true;
                }
            }
        }
    }
}
