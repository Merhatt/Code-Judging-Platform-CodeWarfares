using CodeWarfares.Web.Presenters.Account;
using CodeWarfares.Web.Presenters.Account.Contracts;
using CodeWarfares.Web.Presenters.Codings;
using CodeWarfares.Web.Presenters.Contracts.Account;
using CodeWarfares.Web.Presenters.Contracts.Codings;
using CodeWarfares.Web.Presenters.Contracts.MasterPages;
using CodeWarfares.Web.Presenters.MasterPages;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.App_Start.NinjectModules
{
    public class PresentersNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<ILoginPresenter>().To<LoginPresenter>();
            this.Kernel.Bind<IRegisterPresenter>().To<RegisterPresenter>();
            this.Kernel.Bind<ICompetitionsPresenter>().To<CompetitionsPresenter>();
            this.Kernel.Bind<ISiteMasterPresenter>().To<SiteMasterPresenter>();
            this.Kernel.Bind<IOpenAuthProvidersPresenter>().To<OpenAuthProvidersPresenter>();
            this.Kernel.Bind<ICompetitionsCategoryPresenter>().To<CompetitionsCategoryPresenter>();
        }
    }
}