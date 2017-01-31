using CodeWarfares.Web.Presenters.Contracts.MasterPages;
using CodeWarfares.Web.Views.Contracts.MasterPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Web.Presenters.Factories
{
    public interface ISiteMasterPresenterFactory
    {
        ISiteMasterPresenter Create(ISiteMaster view);
    }
}
