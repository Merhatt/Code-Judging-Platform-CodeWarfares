using CodeWarfares.Data.Models;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using CodeWarfares.Web.EventArguments;
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

        [Test]
        public void ProblemUploadEvent_WrongFileExtention()
        {
            var viewMock = new Mock<IProblemUploadView>();
            var problemService = new Mock<IProblemService>();

            var presenter = new ProblemUploadPresenter(viewMock.Object, problemService.Object);

            var model = new ProblemUploadModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            string fileName = "file.png";
            string problemName = "Cats";
            string imgUrl = "url";
            long maxTime = 200000;
            long maxMemory = 42424;
            int points = 122;
            int testCount = 2;
            string difficulty = "Лесно";

            List<Tuple<string, string>> tests = new List<Tuple<string, string>>();

            tests.Add(new Tuple<string, string>("Kolyo", "Kolyo!"));
            tests.Add(new Tuple<string, string>("Kolyo2", "Kolyo2!"));

            var args = new ProblemUploadClickEventArgs(fileName, problemName, imgUrl, maxTime, maxMemory, points, testCount, tests, difficulty);

            viewMock.Raise(x => x.ProblemUploadEvent += null, args);

            Assert.AreEqual("Изберете файл с формат .docx", model.ErrorText);
            Assert.IsTrue(model.IsErrorActive);
        }

        [Test]
        public void ProblemUploadEvent_CorrectFileExtention_NullProblemName()
        {
            var viewMock = new Mock<IProblemUploadView>();
            var problemService = new Mock<IProblemService>();

            var presenter = new ProblemUploadPresenter(viewMock.Object, problemService.Object);

            var model = new ProblemUploadModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            string fileName = "file.docx";
            string problemName = null;
            string imgUrl = "url";
            long maxTime = 200000;
            long maxMemory = 42424;
            int points = 122;
            int testCount = 2;
            string difficulty = "Лесно";

            List<Tuple<string, string>> tests = new List<Tuple<string, string>>();

            tests.Add(new Tuple<string, string>("Kolyo", "Kolyo!"));
            tests.Add(new Tuple<string, string>("Kolyo2", "Kolyo2!"));

            var args = new ProblemUploadClickEventArgs(fileName, problemName, imgUrl, maxTime, maxMemory, points, testCount, tests, difficulty);

            viewMock.Raise(x => x.ProblemUploadEvent += null, args);

            Assert.AreEqual("Дължината на името на задачата трябва да е по голям от 0", model.ErrorText);
            Assert.IsTrue(model.IsErrorActive);
        }

        [Test]
        public void ProblemUploadEvent_CorrectFileExtention_NullImgUrl()
        {
            var viewMock = new Mock<IProblemUploadView>();
            var problemService = new Mock<IProblemService>();

            var presenter = new ProblemUploadPresenter(viewMock.Object, problemService.Object);

            var model = new ProblemUploadModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            string fileName = "file.docx";
            string problemName = "asd";
            string imgUrl = null;
            long maxTime = 200000;
            long maxMemory = 42424;
            int points = 122;
            int testCount = 2;
            string difficulty = "Лесно";

            List<Tuple<string, string>> tests = new List<Tuple<string, string>>();

            tests.Add(new Tuple<string, string>("Kolyo", "Kolyo!"));
            tests.Add(new Tuple<string, string>("Kolyo2", "Kolyo2!"));

            var args = new ProblemUploadClickEventArgs(fileName, problemName, imgUrl, maxTime, maxMemory, points, testCount, tests, difficulty);

            viewMock.Raise(x => x.ProblemUploadEvent += null, args);

            Assert.AreEqual("Дължината на линка на снимката трябва да е по голям от 0", model.ErrorText);
            Assert.IsTrue(model.IsErrorActive);
        }

        [Test]
        public void ProblemUploadEvent_CorrectFileExtention_MaxMemoryLessThanZero()
        {
            var viewMock = new Mock<IProblemUploadView>();
            var problemService = new Mock<IProblemService>();

            var presenter = new ProblemUploadPresenter(viewMock.Object, problemService.Object);

            var model = new ProblemUploadModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            string fileName = "file.docx";
            string problemName = "asd";
            string imgUrl = "url";
            long maxTime = 200000;
            long maxMemory = -2;
            int points = 122;
            int testCount = 2;
            string difficulty = "Лесно";

            List<Tuple<string, string>> tests = new List<Tuple<string, string>>();

            tests.Add(new Tuple<string, string>("Kolyo", "Kolyo!"));
            tests.Add(new Tuple<string, string>("Kolyo2", "Kolyo2!"));

            var args = new ProblemUploadClickEventArgs(fileName, problemName, imgUrl, maxTime, maxMemory, points, testCount, tests, difficulty);

            viewMock.Raise(x => x.ProblemUploadEvent += null, args);

            Assert.AreEqual("Максималната памет трябва да е над 0", model.ErrorText);
            Assert.IsTrue(model.IsErrorActive);
        }

        [Test]
        public void ProblemUploadEvent_CorrectFileExtention_MaxTimeLessThanZero()
        {
            var viewMock = new Mock<IProblemUploadView>();
            var problemService = new Mock<IProblemService>();

            var presenter = new ProblemUploadPresenter(viewMock.Object, problemService.Object);

            var model = new ProblemUploadModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            string fileName = "file.docx";
            string problemName = "asd";
            string imgUrl = "url";
            long maxTime = -34;
            long maxMemory = 1115;
            int points = 122;
            int testCount = 2;
            string difficulty = "Лесно";

            List<Tuple<string, string>> tests = new List<Tuple<string, string>>();

            tests.Add(new Tuple<string, string>("Kolyo", "Kolyo!"));
            tests.Add(new Tuple<string, string>("Kolyo2", "Kolyo2!"));

            var args = new ProblemUploadClickEventArgs(fileName, problemName, imgUrl, maxTime, maxMemory, points, testCount, tests, difficulty);

            viewMock.Raise(x => x.ProblemUploadEvent += null, args);

            Assert.AreEqual("Максималното време трябва да е над 0", model.ErrorText);
            Assert.IsTrue(model.IsErrorActive);
        }

        [Test]
        public void ProblemUploadEvent_CorrectFileExtention_PointsLessThanZero()
        {
            var viewMock = new Mock<IProblemUploadView>();
            var problemService = new Mock<IProblemService>();

            var presenter = new ProblemUploadPresenter(viewMock.Object, problemService.Object);

            var model = new ProblemUploadModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            string fileName = "file.docx";
            string problemName = "asd";
            string imgUrl = "url";
            long maxTime = 42134;
            long maxMemory = 1115;
            int points = -5;
            int testCount = 3;
            string difficulty = "Лесно";

            List<Tuple<string, string>> tests = new List<Tuple<string, string>>();

            tests.Add(new Tuple<string, string>("Kolyo", "Kolyo!"));
            tests.Add(new Tuple<string, string>("Kolyo2", "Kolyo2!"));

            var args = new ProblemUploadClickEventArgs(fileName, problemName, imgUrl, maxTime, maxMemory, points, testCount, tests, difficulty);

            viewMock.Raise(x => x.ProblemUploadEvent += null, args);

            Assert.AreEqual("Tочките трябва да са над 0", model.ErrorText);
            Assert.IsTrue(model.IsErrorActive);
        }

        [Test]
        public void ProblemUploadEvent_CorrectFileExtention_TestsCountLessThanZero()
        {
            var viewMock = new Mock<IProblemUploadView>();
            var problemService = new Mock<IProblemService>();

            var presenter = new ProblemUploadPresenter(viewMock.Object, problemService.Object);

            var model = new ProblemUploadModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            string fileName = "file.docx";
            string problemName = "asd";
            string imgUrl = "url";
            long maxTime = 42134;
            long maxMemory = 1115;
            int points = 12;
            int testCount = -3;
            string difficulty = "Лесно";

            List<Tuple<string, string>> tests = new List<Tuple<string, string>>();

            tests.Add(new Tuple<string, string>("Kolyo", "Kolyo!"));
            tests.Add(new Tuple<string, string>("Kolyo2", "Kolyo2!"));

            var args = new ProblemUploadClickEventArgs(fileName, problemName, imgUrl, maxTime, maxMemory, points, testCount, tests, difficulty);

            viewMock.Raise(x => x.ProblemUploadEvent += null, args);

            Assert.AreEqual("Тестовете трябва да са повече от 0", model.ErrorText);
            Assert.IsTrue(model.IsErrorActive);
        }

        [Test]
        public void ProblemUploadEvent_CorrectFileExtention_TestsNull()
        {
            var viewMock = new Mock<IProblemUploadView>();
            var problemService = new Mock<IProblemService>();

            var presenter = new ProblemUploadPresenter(viewMock.Object, problemService.Object);

            var model = new ProblemUploadModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            string fileName = "file.docx";
            string problemName = "asd";
            string imgUrl = "url";
            long maxTime = 42134;
            long maxMemory = 1115;
            int points = 12;
            int testCount = 2;
            string difficulty = "Лесно";

            List<Tuple<string, string>> tests = new List<Tuple<string, string>>();

            tests.Add(new Tuple<string, string>(null, "Kolyo!"));
            tests.Add(new Tuple<string, string>("Kolyo2", "Kolyo2!"));

            var args = new ProblemUploadClickEventArgs(fileName, problemName, imgUrl, maxTime, maxMemory, points, testCount, tests, difficulty);

            viewMock.Raise(x => x.ProblemUploadEvent += null, args);

            Assert.AreEqual("Дъжлината на тестовете трябва да са повече от 0", model.ErrorText);
            Assert.IsTrue(model.IsErrorActive);
        }

        [Test]
        public void ProblemUploadEvent_WithoutErrors()
        {
            var viewMock = new Mock<IProblemUploadView>();
            var problemService = new Mock<IProblemService>();

            var presenter = new ProblemUploadPresenter(viewMock.Object, problemService.Object);

            var model = new ProblemUploadModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            string fileName = "file.docx";
            string problemName = "asd";
            string imgUrl = "url";
            long maxTime = 42134;
            long maxMemory = 1115;
            int points = 12;
            int testCount = 2;
            string difficulty = "Лесно";

            List<Tuple<string, string>> tests = new List<Tuple<string, string>>();

            tests.Add(new Tuple<string, string>("Kolyo", "Kolyo!"));
            tests.Add(new Tuple<string, string>("Kolyo2", "Kolyo2!"));

            problemService.Setup(x => x.Create(It.IsAny<Problem>()));

            var args = new ProblemUploadClickEventArgs(fileName, problemName, imgUrl, maxTime, maxMemory, points, testCount, tests, difficulty);

            viewMock.Raise(x => x.ProblemUploadEvent += null, args);

            problemService.Verify(x => x.Create(It.IsAny<Problem>()), Times.Once());
            Assert.AreEqual("~/ProblemDescriptions/ProblemDescription0.docx", model.FileUploadPath);
            Assert.IsTrue(model.ShouldUploadFile);
        }
    }
}
