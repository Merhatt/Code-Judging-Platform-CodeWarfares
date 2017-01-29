using CodeWarfares.Data.Models.Factories;
using CodeWarfares.Data.Services.CodeTesting;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using CodeWarfares.Utils.PassingTests;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Services.Tests.CodeTesting
{
    [TestFixture]
    public class CodeSubmitionServiceTests
    {
        [Test]
        public void Constructor_NullSubmitions_ShouldThrow()
        {
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            Assert.Throws<ArgumentNullException>(() => new CodeSubmitionService(null, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, passingTestCheckerMock.Object));
        }
    }
}
