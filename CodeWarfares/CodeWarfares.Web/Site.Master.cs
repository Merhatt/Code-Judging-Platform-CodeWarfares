using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using CodeWarfares.Web.Views.Contracts.MasterPages;
using CodeWarfares.Web.Presenters.MasterPages;
using CodeWarfares.Web.Views.Models;
using CodeWarfares.Web.EventArguments;
using WebFormsMvp;

namespace CodeWarfares.Web
{
    [PresenterBinding(typeof(SiteMasterPresenter))]
    public partial class SiteMaster : MasterPage, ISiteMaster
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";

        public event EventHandler<MasterPageInitEventArgs> MyInit;
        public event EventHandler<MasterPageValidateTokenEventArgs> ValidateToken;

        public SiteMaster()
        {
            this.Model = new SiteMasterModel();
        }

        private string Cookie
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

        public SiteMasterModel Model { get; set; }

        public bool ThrowExceptionIfNoPresenterBound { get { return true; } }

        protected void Page_Init(object sender, EventArgs e)
        {
            MasterPageInitEventArgs args = new MasterPageInitEventArgs(this.Cookie);
            this.MyInit?.Invoke(sender, args);

            this.Page.ViewStateUserKey = this.Model.ViewStateUserKey;

            if (this.Model.SetCookies)
            {
                SetResponseCookie();
            }
        }

        private void SetResponseCookie()
        {
            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                HttpOnly = true,
                Value = this.Model.ViewStateUserKey
            };

            if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
            {
                responseCookie.Secure = true;
            }

            Response.Cookies.Set(responseCookie);
        }

        protected void PreLoad()
        {
            MasterPageValidateTokenEventArgs args = new MasterPageValidateTokenEventArgs
                (this.IsPostBack, (string)this.ViewState[AntiXsrfUserNameKey], this.Context.User.Identity.Name,
                (string)this.ViewState[AntiXsrfUserNameKey], (string)this.ViewState[AntiXsrfTokenKey]);

            this.ValidateToken?.Invoke(this, args);

            this.ViewState[AntiXsrfTokenKey] = this.Model.TokenKey;
            this.ViewState[AntiXsrfUserNameKey] = this.Model.UserNameKey;
        }

       
        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }

}