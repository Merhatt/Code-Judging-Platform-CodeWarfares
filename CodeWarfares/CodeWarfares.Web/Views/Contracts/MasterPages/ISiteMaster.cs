using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace CodeWarfares.Web.Views.Contracts.MasterPages
{
    public interface ISiteMaster : IView
    {

        string Cookie { get; }

        string ViewStateUserKey { get; set; }

        bool IsPostBack { get; }

        string TokenKey { get; set; }

        string UserNameKey { get; set; }

        IIdentity Identity { get; }
    }
}