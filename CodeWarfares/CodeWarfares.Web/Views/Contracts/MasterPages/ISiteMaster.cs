using CodeWarfares.Web.EventArguments;
using CodeWarfares.Web.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using WebFormsMvp;

namespace CodeWarfares.Web.Views.Contracts.MasterPages
{
    /// <summary>
    /// Site Master page View
    /// </summary>
    public interface ISiteMaster : IView<SiteMasterModel>
    {
        event EventHandler<MasterPageInitEventArgs> MyInit;

        event EventHandler<MasterPageValidateTokenEventArgs> ValidateToken;
    }
}