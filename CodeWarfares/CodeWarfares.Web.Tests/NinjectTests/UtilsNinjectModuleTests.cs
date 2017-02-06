using CodeWarfares.Web.App_Start.NinjectModules;
using Moq;
using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Web.Tests.NinjectTests
{
    [TestFixture]
    public class UtilsNinjectModuleTests
    {
        [Test]
        public void Load_ShouldBindModels()
        {
            var module = new UtilsNinjectModule();

            var kernelMock = new Mock<IKernel>();

            Assert.Throws<NullReferenceException>(() => module.OnLoad(kernelMock.Object));
        }
    }
}
