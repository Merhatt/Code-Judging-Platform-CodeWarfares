using CodeWarfares.Data.Models;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
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
    public class ProblemLeaderboardPresenterTests
    {
        [Test]
        public void Constructor_NullProblemService_ShouldThrow()
        {
            var viewMock = new Mock<IProblemLeaderboardView>();

            var err = Assert.Throws<NullReferenceException>(() => new ProblemLeaderboardPresenter(viewMock.Object, null));

            Assert.AreEqual("problemService cannot be null", err.Message);
        }

        [Test]
        public void Initialize_ShouldSetLeaderboard()
        {
            var viewMock = new Mock<IProblemLeaderboardView>();
            var problemServiceMock = new Mock<IProblemService>();
            var viewModel = new ProblemLeaderboardModel();

            viewMock.SetupGet(x => x.Model).Returns(viewModel);

            var presenter = new ProblemLeaderboardPresenter(viewMock.Object, problemServiceMock.Object);

            var args = new ProblemLeaderboardInitEventArgs(5);

            Problem problem = new Problem();

            problemServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(problem);

            var submitions = new List<Submition>();

            problemServiceMock.Setup(x => x.GetLeaderboard(It.IsAny<Problem>())).Returns(submitions);

            viewMock.Raise(x => x.MyInit += null, args);

            problemServiceMock.Verify(x => x.GetById(5), Times.Once());
            Assert.AreSame(problem, viewModel.ProblemNow);
            problemServiceMock.Verify(x => x.GetLeaderboard(problem), Times.Once());
            Assert.AreSame(submitions, viewModel.Leaderboard);
        }

        [Test]
        public void Initialize_NullProblem_ShouldRedirect()
        {
            var viewMock = new Mock<IProblemLeaderboardView>();
            var problemServiceMock = new Mock<IProblemService>();
            var viewModel = new ProblemLeaderboardModel();

            viewMock.SetupGet(x => x.Model).Returns(viewModel);

            var presenter = new ProblemLeaderboardPresenter(viewMock.Object, problemServiceMock.Object);

            var args = new ProblemLeaderboardInitEventArgs(5);

            Problem problem = null;

            problemServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(problem);

            var submitions = new List<Submition>();

            problemServiceMock.Setup(x => x.GetLeaderboard(It.IsAny<Problem>())).Returns(submitions);

            viewMock.Raise(x => x.MyInit += null, args);

            problemServiceMock.Verify(x => x.GetById(5), Times.Once());
            problemServiceMock.Verify(x => x.GetLeaderboard(It.IsAny<Problem>()), Times.Never());
            Assert.IsTrue(viewModel.PageNotFound);
        }
    }
}
