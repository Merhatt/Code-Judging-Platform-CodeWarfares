using System;
using Ninject.Modules;
using CodeWarfares.Web.Views.Contracts.Account;
using CodeWarfares.Web.Account;
using CodeWarfares.Web.Views.Contracts.Coding;
using CodeWarfares.Web.Codings;
using CodeWarfares.Web.Views.Contracts.MasterPages;
using CodeWarfares.Web.Views.Contracts.Admin;
using CodeWarfares.Web.Admin;

namespace CodeWarfares.Web.App_Start.NinjectModules
{
    public class ViewsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<ILoginView>().To<Login>();
            this.Kernel.Bind<IRegisterView>().To<Register>();
            this.Kernel.Bind<ICompetitionsView>().To<Competitions>();
            this.Kernel.Bind<ICompetitionsCategoryView>().To<CompetitionsCategory>();
            this.Kernel.Bind<ISiteMaster>().To<SiteMaster>();
            this.Kernel.Bind<IOpenAuthProvidersView>().To<OpenAuthProviders>();
            this.Kernel.Bind<ICompetitionProblemView>().To<CompetitionProblem>();
            this.Kernel.Bind<IProblemUploadView>().To<ProblemUpload>();
            this.Kernel.Bind<ILeaderboardView>().To<Leaderboard>();
        }
    }
}