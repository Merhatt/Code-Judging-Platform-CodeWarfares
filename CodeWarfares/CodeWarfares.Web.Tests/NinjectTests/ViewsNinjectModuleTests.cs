using CodeWarfares.Web.Account;
using CodeWarfares.Web.App_Start.NinjectModules;
using CodeWarfares.Web.Codings;
using CodeWarfares.Web.Views.Contracts.Account;
using CodeWarfares.Web.Views.Contracts.Coding;
using CodeWarfares.Web.Views.Contracts.MasterPages;
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
    public class ViewsNinjectModuleTests
    {
        [Test]
        public void Load_ShouldBindModels()
        {
            var module = new ViewsNinjectModule();

            var kernelMock = new Mock<IKernel>();

            var bindingLoginMock = new Mock<IBindingToSyntax<ILoginView>>();
            kernelMock.Setup(x => x.Bind<ILoginView>()).Returns(bindingLoginMock.Object);
            bindingLoginMock.Setup(x => x.To<Login>());

            var bindingRegisterMock = new Mock<IBindingToSyntax<IRegisterView>>();
            kernelMock.Setup(x => x.Bind<IRegisterView>()).Returns(bindingRegisterMock.Object);
            bindingRegisterMock.Setup(x => x.To<Register>());

            var bindingCompetitionsMock = new Mock<IBindingToSyntax<ICompetitionsView>>();
            kernelMock.Setup(x => x.Bind<ICompetitionsView>()).Returns(bindingCompetitionsMock.Object);
            bindingCompetitionsMock.Setup(x => x.To<Competitions>());

            var bindingCompetitionsCategoryMock = new Mock<IBindingToSyntax<ICompetitionsCategoryView>>();
            kernelMock.Setup(x => x.Bind<ICompetitionsCategoryView>()).Returns(bindingCompetitionsCategoryMock.Object);
            bindingCompetitionsCategoryMock.Setup(x => x.To<CompetitionsCategory>());

            var bindingOpenAuthMock = new Mock<IBindingToSyntax<IOpenAuthProvidersView>>();
            kernelMock.Setup(x => x.Bind<IOpenAuthProvidersView>()).Returns(bindingOpenAuthMock.Object);
            bindingOpenAuthMock.Setup(x => x.To<OpenAuthProviders>());

            var bindingSiteMasterMock = new Mock<IBindingToSyntax<ISiteMaster>>();
            kernelMock.Setup(x => x.Bind<ISiteMaster>()).Returns(bindingSiteMasterMock.Object);
            bindingSiteMasterMock.Setup(x => x.To<SiteMaster>());

            module.OnLoad(kernelMock.Object);

            kernelMock.Verify(x => x.Bind<ILoginView>(), Times.Once());
            bindingLoginMock.Verify(x => x.To<Login>(), Times.Once());

            kernelMock.Verify(x => x.Bind<IRegisterView>(), Times.Once());
            bindingRegisterMock.Verify(x => x.To<Register>(), Times.Once());

            kernelMock.Verify(x => x.Bind<ICompetitionsView>(), Times.Once());
            bindingCompetitionsMock.Verify(x => x.To<Competitions>(), Times.Once());

            kernelMock.Verify(x => x.Bind<ICompetitionsCategoryView>(), Times.Once());
            bindingCompetitionsCategoryMock.Verify(x => x.To<CompetitionsCategory>(), Times.Once());

            kernelMock.Verify(x => x.Bind<IOpenAuthProvidersView>(), Times.Once());
            bindingOpenAuthMock.Verify(x => x.To<OpenAuthProviders>(), Times.Once());

            kernelMock.Verify(x => x.Bind<ISiteMaster>(), Times.Once());
            bindingSiteMasterMock.Verify(x => x.To<SiteMaster>(), Times.Once());
        }
    }
}
