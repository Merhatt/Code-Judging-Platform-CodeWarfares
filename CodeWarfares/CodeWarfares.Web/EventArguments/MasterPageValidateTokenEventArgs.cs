using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.EventArguments
{
    public class MasterPageValidateTokenEventArgs : EventArgs
    {
        public MasterPageValidateTokenEventArgs(bool isPostBack, string viewStateUserKey, string identityName, string usernameKey, string tokenKey)
        {
            this.IsPostBack = isPostBack;
            this.ViewStateUserKey = viewStateUserKey;
            this.UsernameKey = usernameKey;
            this.IdentityName = identityName;
            this.TokenKey = tokenKey;
        }

        public bool IsPostBack { get; set; }

        public string ViewStateUserKey { get; set; }

        public string UsernameKey { get; set; }

        public string IdentityName { get; set; }

        public string TokenKey { get; set; }
    }
}