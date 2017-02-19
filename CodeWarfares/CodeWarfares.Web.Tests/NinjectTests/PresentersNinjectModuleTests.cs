using CodeWarfares.Web.App_Start.NinjectModules;
using CodeWarfares.Web.Presenters.Account;
using CodeWarfares.Web.Presenters.Account.Contracts;
using CodeWarfares.Web.Presenters.Admin;
using CodeWarfares.Web.Presenters.Codings;
using CodeWarfares.Web.Presenters.Contracts;
using CodeWarfares.Web.Presenters.Contracts.Account;
using CodeWarfares.Web.Presenters.Contracts.Codings;
using CodeWarfares.Web.Presenters.Contracts.MasterPages;
using CodeWarfares.Web.Presenters.MasterPages;
using Moq;
using Ninject;
using Ninject.Syntax;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Web.Tests.NinjectTests
{
    [TestFixture]
    public class PresentersNinjectModuleTests
    {
        [Test]
        public void Load_ShouldBindModels()
        {
            var module = new PresentersNinjectModule();

            var kernelMock = new Mock<IKernel>();

            var bindingLoginMock = new Mock<IBindingToSyntax<ILoginPresenter>>();
            kernelMock.Setup(x => x.Bind<ILoginPresenter>()).Returns(bindingLoginMock.Object);
            bindingLoginMock.Setup(x => x.To<LoginPresenter>());

            var bindingRegisterMock = new Mock<IBindingToSyntax<IRegisterPresenter>>();
            kernelMock.Setup(x => x.Bind<IRegisterPresenter>()).Returns(bindingRegisterMock.Object);
            bindingRegisterMock.Setup(x => x.To<RegisterPresenter>());

            var bindingCompetitionsMock = new Mock<IBindingToSyntax<ICompetitionsPresenter>>();
            kernelMock.Setup(x => x.Bind<ICompetitionsPresenter>()).Returns(bindingCompetitionsMock.Object);
            bindingCompetitionsMock.Setup(x => x.To<CompetitionsPresenter>());

            var bindingSiteMasterMock = new Mock<IBindingToSyntax<ISiteMasterPresenter>>();
            kernelMock.Setup(x => x.Bind<ISiteMasterPresenter>()).Returns(bindingSiteMasterMock.Object);
            bindingSiteMasterMock.Setup(x => x.To<SiteMasterPresenter>());

            var bindingOpenAuthMock = new Mock<IBindingToSyntax<IOpenAuthProvidersPresenter>>();
            kernelMock.Setup(x => x.Bind<IOpenAuthProvidersPresenter>()).Returns(bindingOpenAuthMock.Object);
            bindingOpenAuthMock.Setup(x => x.To<OpenAuthProvidersPresenter>());

            var bindingCompetitionsCategoryMock = new Mock<IBindingToSyntax<ICompetitionsCategoryPresenter>>();
            kernelMock.Setup(x => x.Bind<ICompetitionsCategoryPresenter>()).Returns(bindingCompetitionsCategoryMock.Object);
            bindingCompetitionsCategoryMock.Setup(x => x.To<CompetitionsCategoryPresenter>());

            var bindingCompetitionsProblemMock = new Mock<IBindingToSyntax<ICompetitionProblemPresenter>>();
            kernelMock.Setup(x => x.Bind<ICompetitionProblemPresenter>()).Returns(bindingCompetitionsProblemMock.Object);
            bindingCompetitionsProblemMock.Setup(x => x.To<CompetitionProblemPresenter>());

            var bindingProblemUploadMock = new Mock<IBindingToSyntax<IProblemUploadPresenter>>();
            kernelMock.Setup(x => x.Bind<IProblemUploadPresenter>()).Returns(bindingProblemUploadMock.Object);
            bindingProblemUploadMock.Setup(x => x.To<ProblemUploadPresenter>());

            var bindingLeaderboardMock = new Mock<IBindingToSyntax<ILeaderboardPresenter>>();
            kernelMock.Setup(x => x.Bind<ILeaderboardPresenter>()).Returns(bindingLeaderboardMock.Object);
            bindingLeaderboardMock.Setup(x => x.To<LeaderboardPresenter>());

            module.OnLoad(kernelMock.Object);

            kernelMock.Verify(x => x.Bind<ILoginPresenter>(), Times.Once());
            bindingLoginMock.Verify(x => x.To<LoginPresenter>(), Times.Once());

            kernelMock.Verify(x => x.Bind<IRegisterPresenter>(), Times.Once());
            bindingRegisterMock.Verify(x => x.To<RegisterPresenter>(), Times.Once());

            kernelMock.Verify(x => x.Bind<ICompetitionsPresenter>(), Times.Once());
            bindingCompetitionsMock.Verify(x => x.To<CompetitionsPresenter>(), Times.Once());

            kernelMock.Verify(x => x.Bind<ISiteMasterPresenter>(), Times.Once());
            bindingOpenAuthMock.Verify(x => x.To<OpenAuthProvidersPresenter>(), Times.Once());

            kernelMock.Verify(x => x.Bind<IOpenAuthProvidersPresenter>(), Times.Once());
            bindingSiteMasterMock.Verify(x => x.To<SiteMasterPresenter>(), Times.Once());

            kernelMock.Verify(x => x.Bind<ICompetitionsCategoryPresenter>(), Times.Once());
            bindingCompetitionsCategoryMock.Verify(x => x.To<CompetitionsCategoryPresenter>(), Times.Once());

            kernelMock.Verify(x => x.Bind<ICompetitionProblemPresenter>(), Times.Once());
            bindingCompetitionsProblemMock.Verify(x => x.To<CompetitionProblemPresenter>(), Times.Once());

            kernelMock.Verify(x => x.Bind<IProblemUploadPresenter>(), Times.Once());
            bindingProblemUploadMock.Verify(x => x.To<ProblemUploadPresenter>(), Times.Once());

            kernelMock.Verify(x => x.Bind<ILeaderboardPresenter>(), Times.Once());
            bindingLeaderboardMock.Verify(x => x.To<LeaderboardPresenter>(), Times.Once());
        }
    }
}
