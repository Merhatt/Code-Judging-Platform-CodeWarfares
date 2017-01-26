using CodeWarfares.Web.Presenters.Account.Contracts;
using CodeWarfares.Web.Views.Contracts.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Web.Presenters.Factories
{
    public interface ILoginPresenterFactory
    {
        ILoginPresenter Create(ILoginView view);
    }
}
