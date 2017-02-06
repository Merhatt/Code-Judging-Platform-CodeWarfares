using System;
using Ninject.Modules;
using CodeWarfares.Web.Views.Contracts.Account;
using CodeWarfares.Web.Account;
using CodeWarfares.Web.Views.Contracts.Coding;
using CodeWarfares.Web.Codings;

namespace CodeWarfares.Web.App_Start.NinjectModules
{
    public class ViewsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<ILoginView>().To<Login>();
            this.Kernel.Bind<IRegisterView>().To<Register>();
            this.Kernel.Bind<IRegisterView>().To<Register>();
            this.Kernel.Bind<ICompetitionsView>().To<Competitions>();
            this.Kernel.Bind<ICompetitionsCategoryView>().To<CompetitionsCategory>();
            this.Kernel.Bind<IOpenAuthProvidersView>().To<OpenAuthProviders>();
        }
    }
}