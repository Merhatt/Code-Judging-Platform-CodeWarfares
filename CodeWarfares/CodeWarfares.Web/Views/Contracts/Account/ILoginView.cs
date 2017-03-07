using CodeWarfares.Data.Services.Contracts.Account;
using CodeWarfares.Web.EventArguments;
using CodeWarfares.Web.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace CodeWarfares.Web.Views.Contracts.Account
{
    /// <summary>
    /// View for the login page
    /// </summary>
    public interface ILoginView : IView<LoginViewModel>
    {
        event EventHandler MyInit;

        event EventHandler<SignInEventArgs> SignInEvent;
    }
}