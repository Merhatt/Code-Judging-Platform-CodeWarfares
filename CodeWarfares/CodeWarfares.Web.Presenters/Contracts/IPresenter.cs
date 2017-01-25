using CodeWarfares.Web.Views.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Web.Presenters.Contracts
{
    public interface IPresenter<TView> where TView : IView
    {
        TView View { get; }
    }
}
