using CodeWarfares.Web.EventArguments;
using CodeWarfares.Web.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace CodeWarfares.Web.Views.Contracts.Account
{
    /// <summary>
    /// Auth Provider View
    /// </summary>
    public interface IOpenAuthProvidersView : IView<OpenAuthProvidersModel>
    {
        event EventHandler<OpenAuthProvidersInitEventArgs> MyInit;
    }
}
