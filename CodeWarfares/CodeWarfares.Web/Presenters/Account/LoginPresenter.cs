using CodeWarfares.Data.Services.Contracts.Account;
using CodeWarfares.Data.Services.Enums;
using CodeWarfares.Web.Presenters.Account.Contracts;
using CodeWarfares.Web.Views.Contracts.Account;

namespace CodeWarfares.Web.Presenters.Account
{
    public class LoginPresenter : Presenter<ILoginView>, ILoginPresenter
    {
        private IUserServices userServices;

        public LoginPresenter(ILoginView view, IUserServices userServices) : base(view)
        {
            this.userServices = userServices;
        }

        public void Initialize()
        {
            this.View.RegisterNavigateUrl = "Register";
        }

        public void SignIn()
        {
            if (this.View.AreFieldsValid)
            {
                var result = this.userServices.PasswordSignIn(this.View.Username, this.View.Password, this.View.AreFieldsValid);

                switch (result)
                {
                    case LoginType.Success:
                        this.View.Success();
                        break;
                    case LoginType.Failure:
                    default:
                        this.View.ErrorText = "Invalid login attempt";
                        this.View.ErrorTextVisible = true;
                        break;
                }
            }
        }
    }
}
