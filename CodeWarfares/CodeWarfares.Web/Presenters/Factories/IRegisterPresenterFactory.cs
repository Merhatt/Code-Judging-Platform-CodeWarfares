using CodeWarfares.Web.Presenters.Contracts.Account;
using CodeWarfares.Web.Views.Contracts.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Web.Presenters.Factories
{
    public interface IRegisterPresenterFactory
    {
        IRegisterPresenter Create(IRegisterView view);
    }
}
