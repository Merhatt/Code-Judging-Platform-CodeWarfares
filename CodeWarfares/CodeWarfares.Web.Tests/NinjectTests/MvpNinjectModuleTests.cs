using CodeWarfares.Web.App_Start.Factories;
using CodeWarfares.Web.App_Start.NinjectModules;
using Moq;
using Ninject;
using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Syntax;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp.Binder;

namespace CodeWarfares.Web.Tests.NinjectTests
{
    [TestFixture]
    public class MvpNinjectModuleTests
    {
        [TestFixture]
        public class DbNinjectModuleTests
        {
            [Test]
            public void Load_ShouldBindModels()
            {
                var module = new MvpNinjectModule();

                var kernelMock = new Mock<IKernel>();

                var bindingMock = new Mock<IBindingToSyntax<IPresenterFactory>>();

                var namedMock = new Mock<IBindingWhenInNamedWithOrOnSyntax<WebFormsMvpPresenterFactory>>();

                kernelMock.Setup(x => x.Bind<IPresenterFactory>()).Returns(bindingMock.Object);

                bindingMock.Setup(x => x.To<WebFormsMvpPresenterFactory>()).Returns(namedMock.Object);

                bool inSingletone = false;

                namedMock.Setup(x => x.InSingletonScope()).Callback(() =>
                {
                    inSingletone = true;
                });

                Assert.Throws<NullReferenceException>(() => module.OnLoad(kernelMock.Object));

                kernelMock.Verify(x => x.Bind<IPresenterFactory>(), Times.Once());
                bindingMock.Verify(x => x.To<WebFormsMvpPresenterFactory>(), Times.Once());
                Assert.IsTrue(inSingletone);
            }

            [Test]
            public void GetPresenter_ShouldReturnCorrectly()
            {
                var module = new MvpNinjectModule();

                var contextMock = new Mock<IContext>();

                var parameters = new List<IParameter>();
                var parameterOneMock = new Mock<IParameter>();
                var parameterTwoMock = new Mock<IParameter>();
                parameters.Add(parameterOneMock.Object);
                parameters.Add(parameterTwoMock.Object);

                contextMock.SetupGet(x => x.Parameters).Returns(parameters);

                Assert.Throws<ArgumentNullException>(() => module.GetPresenter(contextMock.Object));
            }
        }
    }
}
