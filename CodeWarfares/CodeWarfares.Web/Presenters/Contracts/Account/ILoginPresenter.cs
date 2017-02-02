using CodeWarfares.Web.EventArguments;
using System;

namespace CodeWarfares.Web.Presenters.Account.Contracts
{
    public interface ILoginPresenter
    {
        void Initialize(object obj, EventArgs e);

        void SignIn(object sender, SignInEventArgs e);
    }
}