using CodeWarfares.Data.Models;
using CodeWarfares.Data.Services.Contracts.Account;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using CodeWarfares.Data.Services.Enums;
using CodeWarfares.Web.EventArguments;
using CodeWarfares.Web.Presenters.Codings;
using CodeWarfares.Web.Views.Contracts.Coding;
using CodeWarfares.Web.Views.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Web.Presenters.Tests.Codings
{
    [TestFixture]
    public class CompetitionProblemPresenterTests
    {
        [Test]
        public void Constructor_ProblemServiceNull_ShouldThrow()
        {
            var viewMock = new Mock<ICompetitionProblemView>();
            var problemServiceMock = new Mock<IProblemService>();
            var codeSubmitionServiceMock = new Mock<ICodeSubmitionService>();
            var userServiceMock = new Mock<IUserServices>();

            var err = Assert.Throws<NullReferenceException>(() => new CompetitionProblemPresenter(viewMock.Object, null, codeSubmitionServiceMock.Object, userServiceMock.Object));

            Assert.AreEqual("problemService cannot be null", err.Message);
        }

        [Test]
        public void Constructor_CodeSubmitionServiceNull_ShouldThrow()
        {
            var viewMock = new Mock<ICompetitionProblemView>();
            var problemServiceMock = new Mock<IProblemService>();
            var codeSubmitionServiceMock = new Mock<ICodeSubmitionService>();
            var userServiceMock = new Mock<IUserServices>();

            var err = Assert.Throws<NullReferenceException>(() => new CompetitionProblemPresenter(viewMock.Object, problemServiceMock.Object, null, userServiceMock.Object));

            Assert.AreEqual("codeSubmitionService cannot be null", err.Message);
        }

        [Test]
        public void Constructor_UserServiceNull_ShouldThrow()
        {
            var viewMock = new Mock<ICompetitionProblemView>();
            var problemServiceMock = new Mock<IProblemService>();
            var codeSubmitionServiceMock = new Mock<ICodeSubmitionService>();
            var userServiceMock = new Mock<IUserServices>();

            var err = Assert.Throws<NullReferenceException>(() => new CompetitionProblemPresenter(viewMock.Object, problemServiceMock.Object, codeSubmitionServiceMock.Object, null));

            Assert.AreEqual("userServices cannot be null", err.Message);
        }

        [Test]
        public void SetSubmitions_NullUser_ShouldThrow()
        {
            var viewMock = new Mock<ICompetitionProblemView>();
            var problemServiceMock = new Mock<IProblemService>();
            var codeSubmitionServiceMock = new Mock<ICodeSubmitionService>();
            var userServiceMock = new Mock<IUserServices>();

            var competitionProblemPresenter = new CompetitionProblemPresenter(viewMock.Object, problemServiceMock.Object, codeSubmitionServiceMock.Object, userServiceMock.Object);
            var args = new CompetitionProblemEventArgs(2, "Ivan");

            User user = null;

            Problem problem = new Problem();

            userServiceMock.Setup(x => x.GetByUsername(It.IsAny<string>())).Returns(user);
            problemServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(problem);

            var err = Assert.Throws<NullReferenceException>(() => viewMock.Raise(x => x.SetSubmitionsEventArgs += null, args));
            Assert.AreEqual("user cannot be null", err.Message);

            userServiceMock.Verify(x => x.GetByUsername("Ivan"), Times.Once());
            problemServiceMock.Verify(x => x.GetById(2), Times.Once());
        }

        [Test]
        public void SetSubmitions_NullProblem_ShouldThrow()
        {
            var viewMock = new Mock<ICompetitionProblemView>();
            var problemServiceMock = new Mock<IProblemService>();
            var codeSubmitionServiceMock = new Mock<ICodeSubmitionService>();
            var userServiceMock = new Mock<IUserServices>();

            var competitionProblemPresenter = new CompetitionProblemPresenter(viewMock.Object, problemServiceMock.Object, codeSubmitionServiceMock.Object, userServiceMock.Object);
            var args = new CompetitionProblemEventArgs(2, "Ivan");

            User user = new User();

            Problem problem = null;

            userServiceMock.Setup(x => x.GetByUsername(It.IsAny<string>())).Returns(user);
            problemServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(problem);

            var err = Assert.Throws<NullReferenceException>(() => viewMock.Raise(x => x.SetSubmitionsEventArgs += null, args));
            Assert.AreEqual("problem cannot be null", err.Message);

            userServiceMock.Verify(x => x.GetByUsername("Ivan"), Times.Once());
            problemServiceMock.Verify(x => x.GetById(2), Times.Once());
        }

        [Test]
        public void SetSubmitions_ShouldSetSubmitions()
        {
            var viewMock = new Mock<ICompetitionProblemView>();
            var problemServiceMock = new Mock<IProblemService>();
            var codeSubmitionServiceMock = new Mock<ICodeSubmitionService>();
            var userServiceMock = new Mock<IUserServices>();

            var competitionProblemPresenter = new CompetitionProblemPresenter(viewMock.Object, problemServiceMock.Object, codeSubmitionServiceMock.Object, userServiceMock.Object);
            var args = new CompetitionProblemEventArgs(2, "Ivan");

            User user = new User();

            Problem problem = new Problem();

            var model = new CompetitionProblemViewModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            userServiceMock.Setup(x => x.GetByUsername(It.IsAny<string>())).Returns(user);
            problemServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(problem);

            var submitions = new List<Submition>();
            submitions.Add(new Submition());

            codeSubmitionServiceMock.Setup(x => x.GetAllUserSubmition(It.IsAny<User>(), It.IsAny<Problem>())).Returns(submitions);

            viewMock.Raise(x => x.SetSubmitionsEventArgs += null, args);

            userServiceMock.Verify(x => x.GetByUsername("Ivan"), Times.Once());
            problemServiceMock.Verify(x => x.GetById(2), Times.Once());
            codeSubmitionServiceMock.Verify(x => x.GetAllUserSubmition(user, problem), Times.Once());

            Assert.AreSame(submitions.First(), model.UserSubmitions.First());
        }

        [Test]
        public void SendTask_ShouldSendTask()
        {
            var viewMock = new Mock<ICompetitionProblemView>();
            var problemServiceMock = new Mock<IProblemService>();
            var codeSubmitionServiceMock = new Mock<ICodeSubmitionService>();
            var userServiceMock = new Mock<IUserServices>();

            var competitionProblemPresenter = new CompetitionProblemPresenter(viewMock.Object, problemServiceMock.Object, codeSubmitionServiceMock.Object, userServiceMock.Object);

            string code = "Code";
            string laungage = "C#";
            string username = "Ivan";

            var args = new SendTaskEventArgs(code, laungage, username);

            User user = new User();

            var model = new CompetitionProblemViewModel();

            Problem problem = new Problem();

            model.Problem = problem;

            viewMock.SetupGet(x => x.Model).Returns(model);

            userServiceMock.Setup(x => x.GetByUsername(It.IsAny<string>())).Returns(user);
            problemServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(problem);

            var submitions = new List<Submition>();
            submitions.Add(new Submition());

            codeSubmitionServiceMock.Setup(x => x.GetAllUserSubmition(It.IsAny<User>(), It.IsAny<Problem>())).Returns(submitions);

            viewMock.Raise(x => x.SendTaskEvent += null, args);

            userServiceMock.Verify(x => x.GetByUsername(username), Times.Once());
            codeSubmitionServiceMock.Verify(x => x.SendSubmition(user, problem, code, ContestLaungagesTypes.CSharp));
        }

        [Test]
        public void GetDescription_ShouldSetDescriptionToModel()
        {
            var viewMock = new Mock<ICompetitionProblemView>();
            var problemServiceMock = new Mock<IProblemService>();
            var codeSubmitionServiceMock = new Mock<ICodeSubmitionService>();
            var userServiceMock = new Mock<IUserServices>();

            var competitionProblemPresenter = new CompetitionProblemPresenter(viewMock.Object, problemServiceMock.Object, codeSubmitionServiceMock.Object, userServiceMock.Object);

            var args = new EventArgs();

            User user = new User();

            var model = new CompetitionProblemViewModel();

            Problem problem = new Problem();

            problem.Id = 5;

            model.Problem = problem;

            viewMock.SetupGet(x => x.Model).Returns(model);

            userServiceMock.Setup(x => x.GetByUsername(It.IsAny<string>())).Returns(user);
            problemServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(problem);

            var submitions = new List<Submition>();
            submitions.Add(new Submition());

            codeSubmitionServiceMock.Setup(x => x.GetAllUserSubmition(It.IsAny<User>(), It.IsAny<Problem>())).Returns(submitions);

            viewMock.Raise(x => x.GetDescriptionEvent += null, args);

            Assert.AreEqual("/ProblemDescriptions/ProblemDescription5.docx", model.ProblemPath);
        }

        [Test]
        public void Initialization_ShouldInitialize()
        {
            var viewMock = new Mock<ICompetitionProblemView>();
            var problemServiceMock = new Mock<IProblemService>();
            var codeSubmitionServiceMock = new Mock<ICodeSubmitionService>();
            var userServiceMock = new Mock<IUserServices>();

            var competitionProblemPresenter = new CompetitionProblemPresenter(viewMock.Object, problemServiceMock.Object, codeSubmitionServiceMock.Object, userServiceMock.Object);

            int problemId = 2;
            string username = "Gosho";

            var args = new CompetitionProblemEventArgs(problemId, username);

            User user = new User();

            var model = new CompetitionProblemViewModel();

            Problem problem = new Problem();

            problem.Name = "Wow";

            problem.Id = 5;

            model.Problem = problem;

            viewMock.SetupGet(x => x.Model).Returns(model);

            userServiceMock.Setup(x => x.GetByUsername(It.IsAny<string>())).Returns(user);
            problemServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(problem);

            var submitions = new List<Submition>();
            submitions.Add(new Submition());

            codeSubmitionServiceMock.Setup(x => x.GetAllUserSubmition(It.IsAny<User>(), It.IsAny<Problem>())).Returns(submitions);

            viewMock.Raise(x => x.MyInitEvent += null, args);

            userServiceMock.Verify(x => x.GetByUsername(username), Times.Once());
            codeSubmitionServiceMock.Verify(x => x.GetAllUserSubmition(user, problem), Times.Once());
        }
    }
}
