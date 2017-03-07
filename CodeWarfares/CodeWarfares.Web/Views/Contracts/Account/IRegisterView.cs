using CodeWarfares.Data.Services.Contracts.Account;
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
    /// View For Register
    /// </summary>
    public interface IRegisterView : IView<RegisterViewModel>
    {
        event EventHandler<RegisterEventArgs> RegisterEvent;
    }
}
