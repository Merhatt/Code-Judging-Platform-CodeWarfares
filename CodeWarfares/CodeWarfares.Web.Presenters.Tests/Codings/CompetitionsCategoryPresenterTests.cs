using CodeWarfares.Data.Models;
using CodeWarfares.Data.Models.Enums;
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
    public class CompetitionsCategoryPresenterTests
    {
        [Test]
        public void Constructor_NullProblemServices_ShouldThrow()
        {
            var viewMock = new Mock<ICompetitionsCategoryView>();

            var err = Assert.Throws<NullReferenceException>(() => new CompetitionsCategoryPresenter(viewMock.Object, null));

            Assert.AreEqual("problemService cannot be null", err.Message);
        }

        [Test]
        public void Initialize_EasyDifficulty_ShouldSetCorrectly()
        {
            var viewMock = new Mock<ICompetitionsCategoryView>();
            var serviceMock = new Mock<IProblemService>();

            var problems = new List<Problem>()
            {
                new Problem(),
                new Problem()
            };

            CompetitionsCategoryViewModel model = new CompetitionsCategoryViewModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            serviceMock.Setup(x => x.GetAllOrderedByType(It.IsAny<DifficultyType>())).Returns(problems.AsQueryable());

            var presenter = new CompetitionsCategoryPresenter(viewMock.Object, serviceMock.Object);

            string difficulty = "Easy";

            var args = new CompetitionsCategoryEventArgs(difficulty);

            viewMock.Raise(x => x.MyInit += null, args);

            Assert.AreEqual(2, model.Problems.Count());
            Assert.AreEqual("Лесни Задачи", model.CategoryTitle);
            serviceMock.Verify(x => x.GetAllOrderedByType(DifficultyType.Easy), Times.Once());
        }

        [Test]
        public void Initialize_MediumDifficulty_ShouldSetCorrectly()
        {
            var viewMock = new Mock<ICompetitionsCategoryView>();
            var serviceMock = new Mock<IProblemService>();

            var problems = new List<Problem>()
            {
                new Problem(),
                new Problem()
            };

            CompetitionsCategoryViewModel model = new CompetitionsCategoryViewModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            serviceMock.Setup(x => x.GetAllOrderedByType(It.IsAny<DifficultyType>())).Returns(problems.AsQueryable());

            var presenter = new CompetitionsCategoryPresenter(viewMock.Object, serviceMock.Object);

            string difficulty = "Medium";

            var args = new CompetitionsCategoryEventArgs(difficulty);
            viewMock.Raise(x => x.MyInit += null, args);

            Assert.AreEqual(2, model.Problems.Count());
            Assert.AreEqual("Средни Задачи", model.CategoryTitle);
            serviceMock.Verify(x => x.GetAllOrderedByType(DifficultyType.Medium), Times.Once());
        }

        [Test]
        public void Initialize_HardDifficulty_ShouldSetCorrectly()
        {
            var viewMock = new Mock<ICompetitionsCategoryView>();
            var serviceMock = new Mock<IProblemService>();

            var problems = new List<Problem>()
            {
                new Problem(),
                new Problem()
            };

            CompetitionsCategoryViewModel model = new CompetitionsCategoryViewModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            serviceMock.Setup(x => x.GetAllOrderedByType(It.IsAny<DifficultyType>())).Returns(problems.AsQueryable());

            var presenter = new CompetitionsCategoryPresenter(viewMock.Object, serviceMock.Object);

            string difficulty = "Hard";

            var args = new CompetitionsCategoryEventArgs(difficulty);
            viewMock.Raise(x => x.MyInit += null, args);

            Assert.AreEqual(2, model.Problems.Count());
            Assert.AreEqual("Трудни Задачи", model.CategoryTitle);
            serviceMock.Verify(x => x.GetAllOrderedByType(DifficultyType.Hard), Times.Once());
        }

        [Test]
        public void Initialize_VeryHardDifficulty_ShouldSetCorrectly()
        {
            var viewMock = new Mock<ICompetitionsCategoryView>();
            var serviceMock = new Mock<IProblemService>();

            var problems = new List<Problem>()
            {
                new Problem(),
                new Problem()
            };

            CompetitionsCategoryViewModel model = new CompetitionsCategoryViewModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            serviceMock.Setup(x => x.GetAllOrderedByType(It.IsAny<DifficultyType>())).Returns(problems.AsQueryable());

            var presenter = new CompetitionsCategoryPresenter(viewMock.Object, serviceMock.Object);

            string difficulty = "VeryHard";

            var args = new CompetitionsCategoryEventArgs(difficulty);
            viewMock.Raise(x => x.MyInit += null, args);

            Assert.AreEqual(2, model.Problems.Count());
            Assert.AreEqual("Много Трудни Задачи", model.CategoryTitle);
            serviceMock.Verify(x => x.GetAllOrderedByType(DifficultyType.VeryHard), Times.Once());
        }
    }
}
