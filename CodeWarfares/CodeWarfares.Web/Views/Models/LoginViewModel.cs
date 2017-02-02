using CodeWarfares.Data.Services.Contracts.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.Views.Models
{
    public class LoginViewModel
    {
        public string ErrorText { get; set; }

        public bool ErrorTextVisible { get; set; }

        public bool IsSignedIn { get; set; }

        public string RegisterNavigateUrl { get; set; }
    }
}