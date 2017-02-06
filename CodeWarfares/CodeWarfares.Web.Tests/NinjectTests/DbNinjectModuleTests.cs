using CodeWarfares.Data;
using CodeWarfares.Data.Contracts;
using CodeWarfares.Data.Repositories;
using CodeWarfares.Web.App_Start.NinjectModules;
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
    public class DbNinjectModuleTests
    {
        [Test]
        public void Load_ShouldBindModels()
        {
            var module = new DbNinjectModule();

            var kernelMock = new Mock<IKernel>();

            var bindingMock = new Mock<IBindingToSyntax<ICodeWarfaresDbContext>>();

            var namedMock = new Mock<IBindingWhenInNamedWithOrOnSyntax<CodeWarfaresDbContext>>();

            bool inSingletone = false;

            namedMock.Setup(x => x.InSingletonScope()).Callback(() =>
            {
                inSingletone = true;
            });

            var bindingTo = new Mock<IBindingToSyntax<object>>();

            bindingTo.Setup(x => x.To(It.IsAny<Type>()));

            bindingMock.Setup(x => x.To<CodeWarfaresDbContext>()).Returns(namedMock.Object);

            kernelMock.Setup(x => x.Bind<ICodeWarfaresDbContext>()).Returns(bindingMock.Object);

            kernelMock.Setup(x => x.Bind(It.IsAny<Type>())).Returns(bindingTo.Object);

            module.OnLoad(kernelMock.Object);

            kernelMock.Verify(x => x.Bind<ICodeWarfaresDbContext>(), Times.Once());
            bindingMock.Verify(x => x.To<CodeWarfaresDbContext>(), Times.Once());
            Assert.IsTrue(inSingletone);

            kernelMock.Verify(x => x.Bind(typeof(IRepository<>)), Times.Once());
            bindingTo.Verify(x => x.To(typeof(GenericRepository<>)), Times.Once());
        }
    }
}
