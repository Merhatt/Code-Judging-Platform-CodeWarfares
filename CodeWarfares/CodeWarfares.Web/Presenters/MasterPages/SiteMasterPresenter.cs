using CodeWarfares.Web.EventArguments;
using CodeWarfares.Web.Presenters.Contracts;
using CodeWarfares.Web.Presenters.Contracts.MasterPages;
using CodeWarfares.Web.Views.Contracts.MasterPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace CodeWarfares.Web.Presenters.MasterPages
{
    public class SiteMasterPresenter : Presenter<ISiteMaster>, ISiteMasterPresenter
    {
        private string antiXsrfTokenValue;

        public SiteMasterPresenter(ISiteMaster view) : base(view)
        {
            view.MyInit += Initialize;
            view.ValidateToken += ValidateTokens;
        }

        public void Initialize(object sender, MasterPageInitEventArgs e)
        {
            string cookie = e.Cookie;
            Guid requestCookieGuidValue;

            if (cookie != null && Guid.TryParse(cookie, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                this.antiXsrfTokenValue = cookie;
                this.View.Model.ViewStateUserKey = antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                this.antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                this.View.Model.ViewStateUserKey = this.antiXsrfTokenValue;

                this.View.Model.SetCookies = true;
            }
        }

        public void ValidateTokens(object sender, MasterPageValidateTokenEventArgs e)
        {
            if (!e.IsPostBack)
            {
                this.View.Model.TokenKey = e.ViewStateUserKey;
                this.View.Model.UserNameKey = e.IdentityName ?? String.Empty;
            }
            else
            {
                if (e.TokenKey != this.antiXsrfTokenValue
                    || e.UsernameKey != (e.IdentityName ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }
    }
}