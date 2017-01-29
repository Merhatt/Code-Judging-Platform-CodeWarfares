using CodeWarfares.Data.Contracts;
using CodeWarfares.Data.Models;
using CodeWarfares.Data.Models.Factories;
using CodeWarfares.Data.Services.CodeTesting;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using CodeWarfares.Data.Services.Enums;
using CodeWarfares.Utils.JsonModels;
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

        [Test]
        public void Constructor_NullCodeTestingService_ShouldThrow()
        {
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            Assert.Throws<ArgumentNullException>(() => new CodeSubmitionService(repositoryMock.Object, null, submitionFactoryMock.Object, testCompleteFactoryMock.Object, passingTestCheckerMock.Object));
        }

        [Test]
        public void Constructor_NullSubmitionFactory_ShouldThrow()
        {
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            Assert.Throws<ArgumentNullException>(() => new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, null, testCompleteFactoryMock.Object, passingTestCheckerMock.Object));
        }

        [Test]
        public void Constructor_NullTestCompletedFactory_ShouldThrow()
        {
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            Assert.Throws<ArgumentNullException>(() => new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, null, passingTestCheckerMock.Object));
        }

        [Test]
        public void Constructor_NullPassingTestChecker_ShouldThrow()
        {
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            Assert.Throws<ArgumentNullException>(() => new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, null));
        }

        [Test]
        public void Create_NullSubmition_ShouldThrow()
        {
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            var codeSubmitionService = new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, passingTestCheckerMock.Object);

            Assert.Throws<ArgumentNullException>(() => codeSubmitionService.Create(null));
        }

        [Test]
        public void Create_ShouldAddSubmition()
        {
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            var codeSubmitionService = new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, passingTestCheckerMock.Object);
            var submition = new Submition();

            codeSubmitionService.Create(submition);

            repositoryMock.Verify(x => x.Add(submition), Times.Once());
            repositoryMock.Verify(x => x.SaveChanges(), Times.Once());
        }

        [Test]
        public void SendSubmition_UserNull_ShouldThrow()
        {
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            var codeSubmitionService = new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, passingTestCheckerMock.Object);

            User user = new User();
            Problem problem = new Problem();

            Assert.Throws<ArgumentNullException>(() => codeSubmitionService.SendSubmition(null, problem, "asd", ContestLaungagesTypes.CSharp));
        }

        [Test]
        public void SendSubmition_ProblemNull_ShouldThrow()
        {
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            var codeSubmitionService = new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, passingTestCheckerMock.Object);

            User user = new User();
            Problem problem = new Problem();

            Assert.Throws<ArgumentNullException>(() => codeSubmitionService.SendSubmition(user, null, "asd", ContestLaungagesTypes.CSharp));
        }

        [Test]
        public void SendSubmition_SourceNull_ShouldThrow()
        {
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            var codeSubmitionService = new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, passingTestCheckerMock.Object);

            User user = new User();
            Problem problem = new Problem();

            Assert.Throws<ArgumentNullException>(() => codeSubmitionService.SendSubmition(user, problem, null, ContestLaungagesTypes.CSharp));
        }

        [Test]
        public void SendSubmition_AllCorrect_CompileMessageExists()
        {
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            Submition submition = new Submition();

            submitionFactoryMock.Setup(x => x.Create()).Returns(submition);

            var codeSubmitionService = new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, passingTestCheckerMock.Object);

            User user = new User();
            Problem problem = new Problem();
            var test1 = new Test();
            test1.TestParameter = "asd";
            test1.CorrectAnswer = "asd";
            problem.Tests.Add(test1);
            problem.TestsCount = 1;

            SubmitionModel model = new SubmitionModel();
            model.CompileMessage = "It Doesn't work";

            codeTestingServicesMock.Setup(x => x.TestCode(It.IsAny<string>(), It.IsAny<ContestLaungagesTypes>(), It.IsAny<string[]>())).Returns(model);

            string source = "Trooll";

            codeSubmitionService.SendSubmition(user, problem, source, ContestLaungagesTypes.CSharp);

            Assert.AreEqual(false, submition.CanCompile);
            Assert.AreEqual("It Doesn't work", submition.CompileMessage);
            Assert.AreEqual(true, submition.Finished);
            repositoryMock.Verify(x => x.SaveChanges(), Times.Exactly(2));
        }

        [Test]
        public void SendSubmition_AllCorrect_CompileMessageDoesntExist()
        {
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            Submition submition = new Submition();

            submitionFactoryMock.Setup(x => x.Create()).Returns(submition);

            var codeSubmitionService = new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, passingTestCheckerMock.Object);

            User user = new User();
            Problem problem = new Problem();
            var test1 = new Test();
            test1.TestParameter = "asd";
            test1.CorrectAnswer = "asd";
            problem.Tests.Add(test1);
            problem.TestsCount = 1;

            SubmitionModel model = new SubmitionModel();
            model.CompileMessage = null;
            model.Errors = new bool[] { true };

            model.StdOuts = new string[] { "hi" };
            model.Memory = new long[] { 20 };
            model.Times = new double[] { 1 };

            codeTestingServicesMock.Setup(x => x.TestCode(It.IsAny<string>(), It.IsAny<ContestLaungagesTypes>(), It.IsAny<string[]>())).Returns(model);

            string source = "Trooll";

            testCompleteFactoryMock.Setup(x => x.Create()).Returns(new TestCompleted());

            passingTestCheckerMock.Setup(x => x.GetPassingTests(It.IsAny<Submition>(), It.IsAny<Problem>())).Returns(new bool[] { true });

            codeSubmitionService.SendSubmition(user, problem, source, ContestLaungagesTypes.CSharp);

            Assert.AreEqual(true, submition.CanCompile);
            Assert.AreEqual(1, submition.CompletedTests.Count);
            Assert.AreEqual(true, submition.Finished);
            repositoryMock.Verify(x => x.SaveChanges(), Times.Exactly(2));
        }
    }
}
