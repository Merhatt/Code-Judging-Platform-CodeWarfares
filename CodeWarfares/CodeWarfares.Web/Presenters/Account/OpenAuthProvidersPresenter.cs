using CodeWarfares.Web.EventArguments;
using CodeWarfares.Web.Presenters.Contracts.Account;
using CodeWarfares.Web.Views.Contracts.Account;
using CodeWarfares.Web.Views.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace CodeWarfares.Web.Presenters.Account
{
    /// <summary>
    /// Presenter for Open Auth Pages
    /// </summary>
    public class OpenAuthProvidersPresenter : Presenter<IOpenAuthProvidersView>, IOpenAuthProvidersPresenter
    {
        public OpenAuthProvidersPresenter(IOpenAuthProvidersView view) : base(view)
        {
            view.MyInit += this.Initialization;
        }

        private void Initialization(object sender, OpenAuthProvidersInitEventArgs e)
        {
            if (e.IsPostBack == false || e.Provider == null)
            {
                this.View.Model.Completed = false;
                return;
            }

            this.View.Model.RedirectUrl = e.Resolve(String.Format(CultureInfo.InvariantCulture, "~/Account/RegisterExternalLogin?{0}={1}&returnUrl={2}", e.ProviderNameKey, e.Provider, e.ReturnUrl));
        }
    }
}