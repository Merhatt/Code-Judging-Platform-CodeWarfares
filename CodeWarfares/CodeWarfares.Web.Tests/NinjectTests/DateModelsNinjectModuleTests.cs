using CodeWarfares.Web.App_Start.NinjectModules;
using Moq;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Conventions.Syntax;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Web.Tests.NinjectTests
{
    [TestFixture]
    public class DateModelsNinjectModuleTests
    {
        [Test]
        public void Load_ShouldBindModels()
        {
            var module = new DateModelsNinjectModule();

            var kernelMock = new Mock<IKernel>();

            Assert.Throws<NullReferenceException>(() => module.OnLoad(kernelMock.Object));
        }
    }
}
