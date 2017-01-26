using CodeWarfares.Data.Services.Contracts.Account;
using CodeWarfares.Data.Services.Enums;
using CodeWarfares.Web.Presenters.Account.Contracts;
using CodeWarfares.Web.Views.Contracts.Account;

namespace CodeWarfares.Web.Presenters.Account
{
    public class LoginPresenter : Presenter<ILoginView>, ILoginPresenter
    {
        public LoginPresenter(ILoginView view) : base(view)
        {
        }

        public void Initialize()
        {
            this.View.RegisterNavigateUrl = "Register";
        }
    }
}
