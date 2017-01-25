using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.Views.Contracts.Account
{
    public interface ILoginView : IView
    {
        string Username { get; set; }

        string Password { get; set; }

        string ErrorText { get; set; }

        bool ErrorTextVisible { get; set; }

        bool ShouldRemember { get; set; }

        bool AreFieldsValid { get; }

        string RegisterNavigateUrl { get; set; }

        void Success();
    }
}