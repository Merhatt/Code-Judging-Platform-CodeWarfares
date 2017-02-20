using CodeWarfares.Data.Models;
using CodeWarfares.Data.Models.Enums;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
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
    public class CompetitionsPresenterTests
    {
        [Test]
        public void Constructor_NullProblemService_ShouldThrow()
        {
            var viewMock = new Mock<ICompetitionsView>();

            var err = Assert.Throws<NullReferenceException>(() => new CompetitionsPresenter(viewMock.Object, null));

            Assert.AreEqual("problemService cannot be null", err.Message);
        }

        [Test]
        public void Initialize_ShouldSetEasyProblemsCorrectly()
        {
            var viewMock = new Mock<ICompetitionsView>();
            var model = new CompetitionsViewModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            var problemServiceMock = new Mock<IProblemService>();

            var problems = new List<Problem>()
            {
                new Problem(),
                new Problem()
            };

            problemServiceMock.Setup(x => x.GetNewestTopFromCategory(It.IsAny<int>(), It.IsAny<DifficultyType>()))
                                .Returns(problems.AsQueryable());

            var presenter = new CompetitionsPresenter(viewMock.Object, problemServiceMock.Object);

            viewMock.Raise(x => x.MyInit += null, new EventArgs());

            problemServiceMock.Verify(x => x.GetNewestTopFromCategory(4, DifficultyType.Easy), Times.Once());
            Assert.AreEqual(2, model.EasyProblems.ToList().Count);
            Assert.AreSame(problems[0], model.EasyProblems.ToList()[0]);
            Assert.AreSame(problems[1], model.EasyProblems.ToList()[1]);
        }

        [Test]
        public void Initialize_ShouldSetMediumProblemsCorrectly()
        {
            var viewMock = new Mock<ICompetitionsView>();
            var model = new CompetitionsViewModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            var problemServiceMock = new Mock<IProblemService>();

            var problems = new List<Problem>()
            {
                new Problem(),
                new Problem()
            };

            problemServiceMock.Setup(x => x.GetNewestTopFromCategory(It.IsAny<int>(), It.IsAny<DifficultyType>()))
                                .Returns(problems.AsQueryable());

            var presenter = new CompetitionsPresenter(viewMock.Object, problemServiceMock.Object);

            viewMock.Raise(x => x.MyInit += null, new EventArgs());

            problemServiceMock.Verify(x => x.GetNewestTopFromCategory(4, DifficultyType.Medium), Times.Once());
            Assert.AreEqual(2, model.MediumProblems.ToList().Count);
            Assert.AreSame(problems[0], model.MediumProblems.ToList()[0]);
            Assert.AreSame(problems[1], model.MediumProblems.ToList()[1]);
        }

        [Test]
        public void Initialize_ShouldSetHardProblemsCorrectly()
        {
            var viewMock = new Mock<ICompetitionsView>();
            var model = new CompetitionsViewModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            var problemServiceMock = new Mock<IProblemService>();

            var problems = new List<Problem>()
            {
                new Problem(),
                new Problem()
            };

            problemServiceMock.Setup(x => x.GetNewestTopFromCategory(It.IsAny<int>(), It.IsAny<DifficultyType>()))
                                .Returns(problems.AsQueryable());

            var presenter = new CompetitionsPresenter(viewMock.Object, problemServiceMock.Object);

            viewMock.Raise(x => x.MyInit += null, new EventArgs());

            problemServiceMock.Verify(x => x.GetNewestTopFromCategory(4, DifficultyType.Hard), Times.Once());
            Assert.AreEqual(2, model.HardProblems.ToList().Count);
            Assert.AreSame(problems[0], model.HardProblems.ToList()[0]);
            Assert.AreSame(problems[1], model.HardProblems.ToList()[1]);
        }

        [Test]
        public void Initialize_ShouldSetVeryHardProblemsCorrectly()
        {
            var viewMock = new Mock<ICompetitionsView>();
            var model = new CompetitionsViewModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            var problemServiceMock = new Mock<IProblemService>();

            var problems = new List<Problem>()
            {
                new Problem(),
                new Problem()
            };

            problemServiceMock.Setup(x => x.GetNewestTopFromCategory(It.IsAny<int>(), It.IsAny<DifficultyType>()))
                                .Returns(problems.AsQueryable());

            var presenter = new CompetitionsPresenter(viewMock.Object, problemServiceMock.Object);

            viewMock.Raise(x => x.MyInit += null, new EventArgs());

            problemServiceMock.Verify(x => x.GetNewestTopFromCategory(4, DifficultyType.VeryHard), Times.Once());
            Assert.AreEqual(2, model.VeryHardProblems.ToList().Count);
            Assert.AreSame(problems[0], model.VeryHardProblems.ToList()[0]);
            Assert.AreSame(problems[1], model.VeryHardProblems.ToList()[1]);
        }
    }
}
