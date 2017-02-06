using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using CodeWarfares.Utils;
using System.Web.UI;
using CodeWarfares.Web.Views.Contracts.Account;
using CodeWarfares.Web.Views.Models;
using CodeWarfares.Web.EventArguments;
using WebFormsMvp;
using CodeWarfares.Web.Presenters.Account;

namespace CodeWarfares.Web.Account
{
    [PresenterBinding(typeof(OpenAuthProvidersPresenter))]
    public partial class OpenAuthProviders : UserControl, IOpenAuthProvidersView
    {
        public OpenAuthProviders()
        {
            this.Model = new OpenAuthProvidersModel();
        }

        public string ReturnUrl { get; set; }

        public OpenAuthProvidersModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound
        {
            get
            {
                return true;
            }
        }

        public event EventHandler<OpenAuthProvidersInitEventArgs> MyInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            string provider = Request.Form["provider"];
            var args = new OpenAuthProvidersInitEventArgs(this.IsPostBack, provider, IdentityHelper.ProviderNameKey, this.ReturnUrl, this.ResolveUrl);
            this.MyInit?.Invoke(sender, args);
            if (this.Model.Completed == false)
            {
                return;
            }

            var properties = new AuthenticationProperties() { RedirectUri = this.Model.RedirectUrl };
            if (Context.User.Identity.IsAuthenticated)
            {
                properties.Dictionary[IdentityHelper.XsrfKey] = Context.User.Identity.GetUserId();
            }

            Context.GetOwinContext().Authentication.Challenge(properties, provider);
            Response.StatusCode = 401;
            Response.End();
        }

        public IEnumerable<string> GetProviderNames()
        {
            return Context.GetOwinContext().Authentication.GetExternalAuthenticationTypes().Select(t => t.AuthenticationType);
        }
    }
}