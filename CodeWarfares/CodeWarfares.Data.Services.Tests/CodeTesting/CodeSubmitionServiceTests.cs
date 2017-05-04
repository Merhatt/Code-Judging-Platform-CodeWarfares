using CodeWarfares.Data.Contracts;
using CodeWarfares.Data.Models;
using CodeWarfares.Data.Models.Factories;
using CodeWarfares.Data.Services.CodeTesting;
using CodeWarfares.Data.Services.Contracts.Account;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using CodeWarfares.Data.Services.Enums;
using CodeWarfares.Utils.PassingTests;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var userServicesMock = new Mock<IUserServices>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var err = Assert.Throws<NullReferenceException>(() => new CodeSubmitionService(null, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, userServicesMock.Object, unitOfWork.Object));

            Assert.AreEqual("Submitions cannot be null", err.Message);
        }

        [Test]
        public void Constructor_NullCodeTestingService_ShouldThrow()
        {
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();
            var userServicesMock = new Mock<IUserServices>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var err = Assert.Throws<NullReferenceException>(() => new CodeSubmitionService(repositoryMock.Object, null, submitionFactoryMock.Object, testCompleteFactoryMock.Object, userServicesMock.Object, unitOfWork.Object));

            Assert.AreEqual("codeTestingService cannot be null", err.Message);
        }

        [Test]
        public void Constructor_NullSubmitionFactory_ShouldThrow()
        {
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();
            var userServicesMock = new Mock<IUserServices>();
            var unitOfWork = new Mock<IUnitOfWork>();

            var err = Assert.Throws<NullReferenceException>(() => new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, null, testCompleteFactoryMock.Object, userServicesMock.Object, unitOfWork.Object));

            Assert.AreEqual("submitionFactory cannot be null", err.Message);
        }

        [Test]
        public void Constructor_NullTestCompletedFactory_ShouldThrow()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();
            var userServicesMock = new Mock<IUserServices>();

            var err = Assert.Throws<NullReferenceException>(() => new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, null, userServicesMock.Object, unitOfWork.Object));

            Assert.AreEqual("testCompletedFactory cannot be null", err.Message);
        }

        [Test]
        public void Constructor_NullUserServices_ShouldThrow()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();
            var userServicesMock = new Mock<IUserServices>();

            var err = Assert.Throws<NullReferenceException>(() => new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, null, unitOfWork.Object));

            Assert.AreEqual("userServices cannot be null", err.Message);
        }

        [Test]
        public void Create_NullSubmition_ShouldThrow()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var userServicesMock = new Mock<IUserServices>();

            var codeSubmitionService = new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, userServicesMock.Object, unitOfWork.Object);

            var err = Assert.Throws<NullReferenceException>(() => codeSubmitionService.Create(null));

            Assert.AreEqual("submition to add cannot be null", err.Message);
        }

        [Test]
        public void Create_ShouldAddSubmition()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var userServicesMock = new Mock<IUserServices>();

            var codeSubmitionService = new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, userServicesMock.Object, unitOfWork.Object);
            var submition = new Submition();

            codeSubmitionService.Create(submition);

            repositoryMock.Verify(x => x.Add(submition), Times.Once());
            unitOfWork.Verify(x => x.Commit(), Times.Once());
        }

        [Test]
        public void SendSubmition_UserNull_ShouldThrow()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var userServicesMock = new Mock<IUserServices>();

            var codeSubmitionService = new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, userServicesMock.Object, unitOfWork.Object);

            User user = new User();
            Problem problem = new Problem();

            var err = Assert.Throws<NullReferenceException>(() => codeSubmitionService.SendSubmition(null, problem, "asd", ContestLaungagesTypes.CSharp));

            Assert.AreEqual("user cannot be null", err.Message);
        }

        [Test]
        public void SendSubmition_ProblemNull_ShouldThrow()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var userServicesMock = new Mock<IUserServices>();

            var codeSubmitionService = new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, userServicesMock.Object, unitOfWork.Object);

            User user = new User();
            Problem problem = new Problem();

            var err = Assert.Throws<NullReferenceException>(() => codeSubmitionService.SendSubmition(user, null, "asd", ContestLaungagesTypes.CSharp));

            Assert.AreEqual("problem cannot be null", err.Message);
        }

        [Test]
        public void SendSubmition_SourceNull_ShouldThrow()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var userServicesMock = new Mock<IUserServices>();

            var codeSubmitionService = new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, userServicesMock.Object, unitOfWork.Object);

            User user = new User();
            Problem problem = new Problem();

            var err = Assert.Throws<NullReferenceException>(() => codeSubmitionService.SendSubmition(user, problem, null, ContestLaungagesTypes.CSharp));

            Assert.AreEqual("source cannot be null", err.Message);
        }

        [Test]
        public void SendSubmition_AllCorrect_CompileMessageExists()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var userServicesMock = new Mock<IUserServices>();

            Submition submition = new Submition();

            submitionFactoryMock.Setup(x => x.Create()).Returns(submition);

            var codeSubmitionService = new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, userServicesMock.Object, unitOfWork.Object);

            User user = new User();
            user.Id = "waw";
            Problem problem = new Problem();
            var test1 = new Test();
            test1.TestParameter = "asd";
            test1.CorrectAnswer = "asd";
            problem.Tests.Add(test1);
            problem.TestsCount = 1;

            string source = "hello";

            string id = "21";

            codeTestingServicesMock.Setup(x => x.TestCode(It.IsAny<string>(), It.IsAny<ContestLaungagesTypes>(), It.IsAny<string>())).Returns(id);

            testCompleteFactoryMock.Setup(x => x.Create()).Returns(new TestCompleted());

            codeSubmitionService.SendSubmition(user, problem, source, ContestLaungagesTypes.CSharp);

            submitionFactoryMock.Verify(x => x.Create(), Times.Once());
            repositoryMock.Verify(x => x.Add(submition), Times.Once());
            unitOfWork.Verify(x => x.Commit(), Times.Exactly(2));
            userServicesMock.Verify(x => x.AddProblemToUser(user.Id, problem), Times.Once());
            codeTestingServicesMock.Verify(x => x.TestCode(source, ContestLaungagesTypes.CSharp, test1.TestParameter));
            testCompleteFactoryMock.Verify(x => x.Create(), Times.Once());
            Assert.IsTrue(submition.CanCompile);
            Assert.AreEqual(1, submition.CompletedTests.Count);
            Assert.AreEqual(id, submition.CompletedTests.First().SendId);
            Assert.AreEqual(test1.CorrectAnswer, submition.CompletedTests.First().ExpectedResult);
        }

        [Test]
        public void GetAllUserSubmition_UserNull_ShouldThrow()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var userServicesMock = new Mock<IUserServices>();

            var codeSubmitionService = new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, userServicesMock.Object, unitOfWork.Object);

            User user = new User();
            Problem problem = new Problem();

            var err = Assert.Throws<NullReferenceException>(() => codeSubmitionService.GetAllUserSubmition(null, problem));

            Assert.AreEqual("user cannot be null", err.Message);
        }

        [Test]
        public void GetAllUserSubmition_ProblemNull_ShouldThrow()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var userServicesMock = new Mock<IUserServices>();

            var codeSubmitionService = new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, userServicesMock.Object, unitOfWork.Object);

            User user = new User();
            Problem problem = new Problem();

            var err = Assert.Throws<NullReferenceException>(() => codeSubmitionService.GetAllUserSubmition(user, null));

            Assert.AreEqual("problem cannot be null", err.Message);
        }

        [Test]
        public void GetAllUserSubmition_UserSubmitionsNull_ShouldReturnEmptyCollection()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var userServicesMock = new Mock<IUserServices>();

            var codeSubmitionService = new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, userServicesMock.Object, unitOfWork.Object);

            User user = new User();
            Problem problem = new Problem();

            user.Submition = null;

            IEnumerable<Submition> res = codeSubmitionService.GetAllUserSubmition(user, problem);

            Assert.AreEqual(0, res.Count());
        }

        [Test]
        public void GetAllUserSubmition_UserSubmitionsNotNull_ShouldReturnCollection()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IRepository<Submition>>();
            var codeTestingServicesMock = new Mock<ICodeTestingServices>();
            var submitionFactoryMock = new Mock<ISubmitionFactory>();
            var testCompleteFactoryMock = new Mock<ITestCompletedFactory>();
            var userServicesMock = new Mock<IUserServices>();

            var codeSubmitionService = new CodeSubmitionService(repositoryMock.Object, codeTestingServicesMock.Object, submitionFactoryMock.Object, testCompleteFactoryMock.Object, userServicesMock.Object, unitOfWork.Object);

            User user = new User();
            Problem problem = new Problem();

            problem.Id = 2;

            Submition sub1 = new Submition();
            sub1.ProblemId = 2;

            Submition sub2 = new Submition();
            sub2.ProblemId = 2;

            Submition sub3 = new Submition();
            sub3.ProblemId = 3;

            user.Submition.Add(sub1);
            user.Submition.Add(sub2);
            user.Submition.Add(sub3);

            codeTestingServicesMock.Setup(x => x.GetAreAllTestsCompleted(It.IsAny<Problem>(), It.IsAny<Submition>())).Returns(true);

            IEnumerable<Submition> res = codeSubmitionService.GetAllUserSubmition(user, problem);

            Assert.AreEqual(2, res.Count());
            Assert.IsTrue(sub1.Finished);
            Assert.IsTrue(sub2.Finished);
            Assert.IsFalse(sub3.Finished);

            unitOfWork.Verify(x => x.Commit(), Times.Exactly(2));
        }
    }
}
