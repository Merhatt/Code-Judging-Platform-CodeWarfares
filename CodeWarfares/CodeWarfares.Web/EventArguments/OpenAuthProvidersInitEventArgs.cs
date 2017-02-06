using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.EventArguments
{
    public class OpenAuthProvidersInitEventArgs : EventArgs
    {
        public OpenAuthProvidersInitEventArgs(bool isPostBack, string provider, string providerNameKey, string returnUrl, Func<string, string> resolve)
        {
            this.IsPostBack = isPostBack;
            this.Provider = provider;
            this.Resolve = resolve;
            this.ProviderNameKey = providerNameKey;
            this.ReturnUrl = returnUrl;
        }

        public bool IsPostBack { get; set; }

        public string Provider { get; set; }

        public string ProviderNameKey { get; set; }

        public string ReturnUrl { get; set; }

        public Func<string, string> Resolve { get; set; }
    }
}