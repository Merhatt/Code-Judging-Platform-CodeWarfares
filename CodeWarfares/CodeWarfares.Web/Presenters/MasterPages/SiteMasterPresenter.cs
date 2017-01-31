using CodeWarfares.Web.Presenters.Contracts;
using CodeWarfares.Web.Presenters.Contracts.MasterPages;
using CodeWarfares.Web.Views.Contracts.MasterPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.Presenters.MasterPages
{
    public class SiteMasterPresenter : Presenter<ISiteMaster>, ISiteMasterPresenter
    {
        private string antiXsrfTokenValue;
        public event EventHandler SetResponseCookieEvent;

        public SiteMasterPresenter(ISiteMaster view) : base(view)
        {
        }

        public void Initialize()
        {
            string cookie = this.View.Cookie;
            Guid requestCookieGuidValue;

            if (cookie != null && Guid.TryParse(cookie, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                this.antiXsrfTokenValue = cookie;
                this.View.ViewStateUserKey = antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                this.antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                this.View.ViewStateUserKey = this.antiXsrfTokenValue;

                this.SetResponseCookieEvent.Invoke("Presenter", new EventArgs());
            }
        }

        public void ValidateTokens()
        {
            if (!this.View.IsPostBack)
            {
                this.View.TokenKey = this.View.ViewStateUserKey;
                this.View.UserNameKey = this.View.Identity.Name ?? String.Empty;
            }
            else
            {
                if (this.View.TokenKey != this.antiXsrfTokenValue
                    || this.View.UserNameKey != (this.View.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }
    }
}