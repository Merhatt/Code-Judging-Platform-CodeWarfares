using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using CodeWarfares.Web.Views.Contracts;
using CodeWarfares.Web.Views.Contracts.MasterPages;
using CodeWarfares.Web.Presenters.Factories;
using Ninject;
using CodeWarfares.Web.Presenters.Contracts.MasterPages;
using Ninject.Web;
using CodeWarfares.Web.Presenters.MasterPages;

namespace CodeWarfares.Web
{
    public partial class SiteMaster : MasterPageBase, ISiteMaster
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";

        public SiteMaster()
        {
            this.SiteMasterPresenter = new SiteMasterPresenter(this);
        }

        //It does't work because Page must be called in Page Init but factori is injected in page load :(
        //[Inject]
        //public ISiteMasterPresenterFactory SiteMasterPresenterFactory { get; set; }

        public ISiteMasterPresenter SiteMasterPresenter { get; set; }

        public string Cookie
        {
            get
            {
                if (Request.Cookies[AntiXsrfTokenKey] == null)
                {
                    return null;
                }
                else
                {
                    return Request.Cookies[AntiXsrfTokenKey].Value;
                }
            }
        }

        public string ViewStateUserKey
        {
            get
            {
                return this.Page.ViewStateUserKey;
            }

            set
            {
                this.Page.ViewStateUserKey = value;
            }
        }

        public string TokenKey
        {
            get
            {
                return (string)this.ViewState[AntiXsrfTokenKey];
            }

            set
            {
                this.ViewState[AntiXsrfTokenKey] = value;
            }
        }

        public string UserNameKey
        {
            get
            {
                return (string)this.ViewState[AntiXsrfUserNameKey];
            }

            set
            {
                this.ViewState[AntiXsrfUserNameKey] = value;
            }
        }

        public IIdentity Identity
        {
            get
            {
                return this.Context.User.Identity;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.SiteMasterPresenter.SetResponseCookieEvent += new EventHandler(SetResponseCookie);
            this.SiteMasterPresenter.Initialize();
        }

        public void SetResponseCookie(object sender, EventArgs e)
        {
            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                HttpOnly = true,
                Value = this.ViewStateUserKey
            };

            if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
            {
                responseCookie.Secure = true;
            }

            Response.Cookies.Set(responseCookie);
        }

        protected void PreLoad()
        {
            this.SiteMasterPresenter.ValidateTokens();
        }

       
        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }

}