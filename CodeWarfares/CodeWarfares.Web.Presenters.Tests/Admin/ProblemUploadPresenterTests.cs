using CodeWarfares.Data.Services.Contracts.CodeTesting;
using CodeWarfares.Web.Presenters.Admin;
using CodeWarfares.Web.Views.Contracts.Admin;
using CodeWarfares.Web.Views.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Web.Presenters.Tests.Admin
{
    [TestFixture]
    public class ProblemUploadPresenterTests
    {
        [Test]
        public void Constructor_NullProblemService_ShouldThrow()
        {
            var viewMock = new Mock<IProblemUploadView>();

            var err = Assert.Throws<NullReferenceException>(() => new ProblemUploadPresenter(viewMock.Object, null));

            Assert.AreEqual("ProblemService cannot be null", err.Message);
        }

        [Test]
        public void Initializationr_ShouldSetDifficulty()
        {
            var viewMock = new Mock<IProblemUploadView>();
            var problemService = new Mock<IProblemService>();

            var presenter = new ProblemUploadPresenter(viewMock.Object, problemService.Object);

            var model = new ProblemUploadModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            var difficulties = new List<string>()
            {
                "Лесно",
                "Средно",
                "Трудно",
                "Много Трудно",
            };

            viewMock.Raise(x => x.MyInit += null, new EventArgs());

            Assert.AreEqual(difficulties, model.Difficulties);
        }
    }
}
