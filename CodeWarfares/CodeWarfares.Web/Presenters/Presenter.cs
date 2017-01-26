using CodeWarfares.Web.Presenters.Contracts;
using CodeWarfares.Web.Views.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Web.Presenters
{
    public abstract class Presenter<TView> : IPresenter<TView> where TView : IView
    {
        private TView view;

        public Presenter(TView view)
        {
            this.View = view;
        }

        public TView View
        {
            get
            {
                return this.view;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("View cannot be null");
                }

                this.view = value;
            }
        }
    }
}
