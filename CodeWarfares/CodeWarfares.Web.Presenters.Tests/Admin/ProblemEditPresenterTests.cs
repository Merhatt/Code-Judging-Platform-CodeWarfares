using CodeWarfares.Data.Models;
using CodeWarfares.Data.Models.Enums;
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
    public class ProblemEditPresenterTests
    {
        [Test]
        public void DeleteProblem_ShouldCallDeleteProblem()
        {
            //Arrange
            var viewMock = new Mock<IProblemEditView>();
            var problemServicesMock = new Mock<IProblemService>();

            var presenter = new ProblemEditPresenter(viewMock.Object, problemServicesMock.Object);

            //Act
            viewMock.Raise(x => x.DeleteProblem += null, new ProblemEditInitEventArgs(2));

            //Assert
            problemServicesMock.Verify(x => x.DeleteProblem(2), Times.Once());
        }

        [Test]
        public void InitProblem_NullProblem_ShouldReturn()
        {
            //Arrange
            var viewMock = new Mock<IProblemEditView>();
            var problemServicesMock = new Mock<IProblemService>();

            Problem problem = null;

            ProblemEditModel model = new ProblemEditModel();

            viewMock.SetupGet(x => x.Model)
                .Returns(model);

            problemServicesMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(problem);

            var presenter = new ProblemEditPresenter(viewMock.Object, problemServicesMock.Object);

            //Act
            viewMock.Raise(x => x.InitProblem += null, new ProblemEditInitEventArgs(2));

            //Assert
            problemServicesMock.Verify(x => x.GetById(2), Times.Once());
            Assert.IsTrue(model.NotFoundPage);
        }

        [Test]
        public void InitProblem_ShouldInit()
        {
            //Arrange
            var viewMock = new Mock<IProblemEditView>();
            var problemServicesMock = new Mock<IProblemService>();

            Problem problem = new Problem();

            ProblemEditModel model = new ProblemEditModel();

            viewMock.SetupGet(x => x.Model)
                .Returns(model);

            problemServicesMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(problem);

            var presenter = new ProblemEditPresenter(viewMock.Object, problemServicesMock.Object);

            //Act
            viewMock.Raise(x => x.InitProblem += null, new ProblemEditInitEventArgs(2));

            //Assert
            problemServicesMock.Verify(x => x.GetById(2), Times.Once());
            Assert.IsFalse(model.NotFoundPage);
            Assert.AreSame(problem, model.ProblemNow);
        }

        [Test]
        public void EditProblem_WrongFileExtention()
        {
            var viewMock = new Mock<IProblemEditView>();
            var problemService = new Mock<IProblemService>();

            var presenter = new ProblemEditPresenter(viewMock.Object, problemService.Object);

            var model = new ProblemEditModel();

            viewMock.SetupGet(x => x.Model)
                .Returns(model);

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

            viewMock.Raise(x => x.EditProblem += null, args);

            Assert.AreEqual("Изберете файл с формат .docx", model.ErrorText);
            Assert.IsTrue(model.IsErrorActive);
        }

        [Test]
        public void EditProblem_CorrectFileExtention_NullProblemName()
        {
            var viewMock = new Mock<IProblemEditView>();
            var problemService = new Mock<IProblemService>();

            var presenter = new ProblemEditPresenter(viewMock.Object, problemService.Object);

            var model = new ProblemEditModel();

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

            viewMock.Raise(x => x.EditProblem += null, args);

            Assert.AreEqual("Дължината на името на задачата трябва да е по голям от 0", model.ErrorText);
            Assert.IsTrue(model.IsErrorActive);
        }

        [Test]
        public void EditProblem_CorrectFileExtention_NullImgUrl()
        {
            var viewMock = new Mock<IProblemEditView>();
            var problemService = new Mock<IProblemService>();

            var presenter = new ProblemEditPresenter(viewMock.Object, problemService.Object);

            var model = new ProblemEditModel();

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

            viewMock.Raise(x => x.EditProblem += null, args);

            Assert.AreEqual("Дължината на линка на снимката трябва да е по голям от 0", model.ErrorText);
            Assert.IsTrue(model.IsErrorActive);
        }

        [Test]
        public void EditProblem_CorrectFileExtention_MaxMemoryLessThanZero()
        {
            var viewMock = new Mock<IProblemEditView>();
            var problemService = new Mock<IProblemService>();

            var presenter = new ProblemEditPresenter(viewMock.Object, problemService.Object);

            var model = new ProblemEditModel();

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

            viewMock.Raise(x => x.EditProblem += null, args);

            Assert.AreEqual("Максималната памет трябва да е над 0", model.ErrorText);
            Assert.IsTrue(model.IsErrorActive);
        }

        [Test]
        public void EditProblem_CorrectFileExtention_MaxTimeLessThanZero()
        {
            var viewMock = new Mock<IProblemEditView>();
            var problemService = new Mock<IProblemService>();

            var presenter = new ProblemEditPresenter(viewMock.Object, problemService.Object);

            var model = new ProblemEditModel();

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

            viewMock.Raise(x => x.EditProblem += null, args);

            Assert.AreEqual("Максималното време трябва да е над 0", model.ErrorText);
            Assert.IsTrue(model.IsErrorActive);
        }

        [Test]
        public void EditProblem_CorrectFileExtention_PointsLessThanZero()
        {
            var viewMock = new Mock<IProblemEditView>();
            var problemService = new Mock<IProblemService>();

            var presenter = new ProblemEditPresenter(viewMock.Object, problemService.Object);

            var model = new ProblemEditModel();

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

            viewMock.Raise(x => x.EditProblem += null, args);

            Assert.AreEqual("Tочките трябва да са над 0", model.ErrorText);
            Assert.IsTrue(model.IsErrorActive);
        }

        [Test]
        public void EditProblem_CorrectFileExtention_TestsCountLessThanZero()
        {
            var viewMock = new Mock<IProblemEditView>();
            var problemService = new Mock<IProblemService>();

            var presenter = new ProblemEditPresenter(viewMock.Object, problemService.Object);

            var model = new ProblemEditModel();

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

            viewMock.Raise(x => x.EditProblem += null, args);

            Assert.AreEqual("Тестовете трябва да са повече от 0", model.ErrorText);
            Assert.IsTrue(model.IsErrorActive);
        }

        [Test]
        public void EditProblem_CorrectFileExtention_TestsNull()
        {
            var viewMock = new Mock<IProblemEditView>();
            var problemService = new Mock<IProblemService>();

            var presenter = new ProblemEditPresenter(viewMock.Object, problemService.Object);

            var model = new ProblemEditModel();

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

            viewMock.Raise(x => x.EditProblem += null, args);

            Assert.AreEqual("Дъжлината на тестовете трябва да са повече от 0", model.ErrorText);
            Assert.IsTrue(model.IsErrorActive);
        }

        [Test]
        public void ProblemUploadEvent_WithoutErrors()
        {
            //Arrange
            var viewMock = new Mock<IProblemEditView>();
            var problemService = new Mock<IProblemService>();

            var presenter = new ProblemEditPresenter(viewMock.Object, problemService.Object);

            var model = new ProblemEditModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            model.ProblemNow = new Problem();
            model.ProblemNow.Id = 2;

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

            List<Test> allTests = new List<Test>();

            var args = new ProblemUploadClickEventArgs(fileName, problemName, imgUrl, maxTime, maxMemory, points, testCount, tests, difficulty);

            //Act
            viewMock.Raise(x => x.EditProblem += null, args);

            //Assert
            problemService.Verify(x => x.EditProblem(2, problemName, imgUrl, maxMemory,
                maxTime, points, testCount, DifficultyType.Easy, It.IsAny<IEnumerable<Test>>()), Times.Once());
            Assert.AreEqual("~/ProblemDescriptions/ProblemDescription2.docx", model.FileUploadPath);
            Assert.IsTrue(model.ShouldUploadFile);
        }
    }
}
