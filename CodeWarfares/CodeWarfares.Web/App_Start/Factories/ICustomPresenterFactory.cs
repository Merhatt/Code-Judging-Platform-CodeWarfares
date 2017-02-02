using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace CodeWarfares.Web.App_Start.Factories
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}
