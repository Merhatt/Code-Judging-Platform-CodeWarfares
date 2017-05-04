using CodeWarfares.Data.Contracts;
using CodeWarfares.Data.Models;
using CodeWarfares.Data.Models.Enums;
using CodeWarfares.Data.Services.CodeTesting;
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
    public class ProblemServiceTests
    {
        [Test]
        public void Constructor_NullProblems_ShouldThrow()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var testsMock = new Mock<IRepository<Test>>();
            var err = Assert.Throws<NullReferenceException>(() => new ProblemService(null, testsMock.Object, unitOfWorkMock.Object));
            Assert.AreEqual("problems cannot be null", err.Message);
        }

        [Test]
        public void GetAll_ShouldReturnAll()
        {
            var problemsMock = new Mock<IRepository<Problem>>();
            var queriableMock = new Mock<IQueryable<Problem>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var testsMock = new Mock<IRepository<Test>>();

            problemsMock.Setup(x => x.All()).Returns(queriableMock.Object);

            var problemService = new ProblemService(problemsMock.Object, testsMock.Object, unitOfWorkMock.Object);

            var result = problemService.GetAll();

            Assert.AreSame(queriableMock.Object, result);
        }

        [Test]
        public void GetAllOrderedByType_NullAll_ShouldReturnEmptyQueriable()
        {
            var problemsMock = new Mock<IRepository<Problem>>();
            Problem problem = new Problem();
            problem.CreationTime = DateTime.Now;
            problem.Difficulty = DifficultyType.Easy;
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            Problem problem2 = new Problem();
            problem2.CreationTime = DateTime.Now;
            problem2.Difficulty = DifficultyType.Hard;

            IQueryable<Problem> problems = null;

            problemsMock.Setup(x => x.All()).Returns(problems);
            var testsMock = new Mock<IRepository<Test>>();

            var problemService = new ProblemService(problemsMock.Object, testsMock.Object, unitOfWorkMock.Object);

            var problemsRes = problemService.GetAllOrderedByType(DifficultyType.Easy).ToList();

            Assert.AreEqual(0, problemsRes.Count);
        }

        [Test]
        public void GetAllOrderedByType_EmptyAll_ShouldReturnEmptyQueriable()
        {
            var problemsMock = new Mock<IRepository<Problem>>();
            Problem problem = new Problem();
            problem.CreationTime = DateTime.Now;
            problem.Difficulty = DifficultyType.Easy;

            Problem problem2 = new Problem();
            problem2.CreationTime = DateTime.Now;
            problem2.Difficulty = DifficultyType.Hard;
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            IQueryable<Problem> problems = new List<Problem>().AsQueryable();

            problemsMock.Setup(x => x.All()).Returns(problems);
            var testsMock = new Mock<IRepository<Test>>();

            var problemService = new ProblemService(problemsMock.Object, testsMock.Object, unitOfWorkMock.Object);

            var problemsRes = problemService.GetAllOrderedByType(DifficultyType.Easy).ToList();

            Assert.AreEqual(0, problemsRes.Count);
        }

        [Test]
        public void GetAllOrderedByType_ZeroInCategory_ShouldReturnEmptyIQueriable()
        {
            var problemsMock = new Mock<IRepository<Problem>>();
            Problem problem = new Problem();
            problem.CreationTime = DateTime.Now;
            problem.Difficulty = DifficultyType.Easy;

            Problem problem2 = new Problem();
            problem2.CreationTime = DateTime.Now;
            problem2.Difficulty = DifficultyType.Hard;
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var testsMock = new Mock<IRepository<Test>>();

            var problems = new List<Problem>()
            {
                problem,
                problem2
            };

            problemsMock.Setup(x => x.All()).Returns(problems.AsQueryable());

            var problemService = new ProblemService(problemsMock.Object, testsMock.Object, unitOfWorkMock.Object);

            var problemsRes = problemService.GetAllOrderedByType(DifficultyType.Medium).ToList();

            Assert.AreEqual(0, problemsRes.Count);
        }

        [Test]
        public void GetAllOrderedByType_ShouldReturnAll()
        {
            var problemsMock = new Mock<IRepository<Problem>>();
            Problem problem = new Problem();
            problem.CreationTime = DateTime.Now;
            problem.Difficulty = DifficultyType.Easy;
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            Problem problem2 = new Problem();
            problem2.CreationTime = DateTime.Now;
            problem2.Difficulty = DifficultyType.Hard;
            var testsMock = new Mock<IRepository<Test>>();

            var problems = new List<Problem>()
            {
                problem,
                problem2
            };

            problemsMock.Setup(x => x.All()).Returns(problems.AsQueryable());

            var problemService = new ProblemService(problemsMock.Object, testsMock.Object, unitOfWorkMock.Object);

            var problemsRes = problemService.GetAllOrderedByType(DifficultyType.Easy).ToList();

            Assert.AreEqual(1, problemsRes.Count);
            Assert.AreSame(problem, problemsRes[0]);
        }

        [Test]
        public void GetById_ShouldReturnCorrectly()
        {
            var problemsMock = new Mock<IRepository<Problem>>();

            Problem problem = new Problem();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var testsMock = new Mock<IRepository<Test>>();

            problemsMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(problem);

            var problemService = new ProblemService(problemsMock.Object, testsMock.Object, unitOfWorkMock.Object);

            var result = problemService.GetById(2);

            Assert.AreSame(problem, result);
        }

        [Test]
        public void Create_NullProblem_ShouldThrow()
        {
            var problemsMock = new Mock<IRepository<Problem>>();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            Problem problem = new Problem();

            problemsMock.Setup(x => x.Add(It.IsAny<Problem>()));
            var testsMock = new Mock<IRepository<Test>>();

            var problemService = new ProblemService(problemsMock.Object, testsMock.Object, unitOfWorkMock.Object);

            Assert.Throws<ArgumentNullException>(() => problemService.Create(null));
        }

        [Test]
        public void Create_ValdProblem_ShouldCreate()
        {
            var problemsMock = new Mock<IRepository<Problem>>();

            Problem problem = new Problem();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var testsMock = new Mock<IRepository<Test>>();

            problemsMock.Setup(x => x.Add(It.IsAny<Problem>()));

            var problemService = new ProblemService(problemsMock.Object, testsMock.Object, unitOfWorkMock.Object);

            problemService.Create(problem);

            problemsMock.Verify(x => x.Add(problem), Times.Once());
            unitOfWorkMock.Verify(x => x.Commit(), Times.Once());
        }

        [Test]
        public void DeleteProblem_InvalidId_ShouldReturn()
        {
            //Arrange
            var problemsMock = new Mock<IRepository<Problem>>();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            
            var testsMock = new Mock<IRepository<Test>>();

            Problem problemToDelete = null;

            problemsMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(problemToDelete);

            var problemService = new ProblemService(problemsMock.Object, testsMock.Object, unitOfWorkMock.Object);

            //Act
            problemService.DeleteProblem(2);

            //Assert
            problemsMock.Verify(x => x.GetById(2), Times.Once());
            problemsMock.Verify(x => x.Delete(It.IsAny<Problem>()), Times.Never());
            unitOfWorkMock.Verify(x => x.Commit(), Times.Never());
        }

        [Test]
        public void DeleteProblem_ValidId_ShouldRemove()
        {
            //Arrange
            var problemsMock = new Mock<IRepository<Problem>>();

            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var testsMock = new Mock<IRepository<Test>>();

            Problem problemToDelete = new Problem()
            {
            };

            problemsMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(problemToDelete);

            var problemService = new ProblemService(problemsMock.Object, testsMock.Object, unitOfWorkMock.Object);

            //Act
            problemService.DeleteProblem(2);

            //Assert
            problemsMock.Verify(x => x.GetById(2), Times.Once());
            problemsMock.Verify(x => x.Delete(problemToDelete), Times.Once());
            unitOfWorkMock.Verify(x => x.Commit(), Times.Once());
        }

        [Test]
        public void AddSubmitionToProblem_InvaldProblem_ShouldThrow()
        {
            var problemsMock = new Mock<IRepository<Problem>>();

            Problem problem = new Problem();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            problemsMock.Setup(x => x.Add(It.IsAny<Problem>()));
            var testsMock = new Mock<IRepository<Test>>();

            var problemService = new ProblemService(problemsMock.Object, testsMock.Object, unitOfWorkMock.Object);

            Assert.Throws<ArgumentNullException>(() => problemService.AddSubmitionToProblem(2, null));
        }

        [Test]
        public void AddSubmitionToProblem_CorrectProblem()
        {
            var problemsMock = new Mock<IRepository<Problem>>();

            Problem problem = new Problem();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            problemsMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(problem);

            problemsMock.Setup(x => x.Add(It.IsAny<Problem>()));
            var testsMock = new Mock<IRepository<Test>>();

            var problemService = new ProblemService(problemsMock.Object, testsMock.Object, unitOfWorkMock.Object);

            var submition = new Submition();

            problemService.AddSubmitionToProblem(2, submition);

            Assert.AreSame(submition, problem.Submitions.First());
            unitOfWorkMock.Verify(x => x.Commit(), Times.Once());
        }

        [Test]
        public void GetNewestTopFromCategory_CountLessThanZero_ShouldThrow()
        {
            var problemsMock = new Mock<IRepository<Problem>>();

            Problem problem = new Problem();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var testsMock = new Mock<IRepository<Test>>();

            var problemService = new ProblemService(problemsMock.Object, testsMock.Object, unitOfWorkMock.Object);

            Assert.Throws<ArgumentException>(() => problemService.GetNewestTopFromCategory(-1, DifficultyType.Easy));
        }

        [Test]
        public void GetNewestTopFromCategory_ShouldReturnProblems()
        {
            var problemsMock = new Mock<IRepository<Problem>>();
            Problem problem = new Problem();
            problem.CreationTime = DateTime.Now;
            problem.Difficulty = DifficultyType.Easy;

            Problem problem2 = new Problem();
            problem2.CreationTime = DateTime.Now;
            problem2.Difficulty = DifficultyType.Hard;
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var problems = new List<Problem>()
            {
                problem,
                problem2
            };

            problemsMock.Setup(x => x.All()).Returns(problems.AsQueryable());
            var testsMock = new Mock<IRepository<Test>>();

            var problemService = new ProblemService(problemsMock.Object, testsMock.Object, unitOfWorkMock.Object);

            var problemsRes = problemService.GetNewestTopFromCategory(5, DifficultyType.Easy).ToList();

            Assert.AreEqual(1, problemsRes.Count);
            Assert.AreSame(problem, problemsRes[0]);
        }

        [Test]
        public void GetLeaderboard_NullProblem_ShouldThrow()
        {
            var problemsMock = new Mock<IRepository<Problem>>();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var testsMock = new Mock<IRepository<Test>>();

            var problemService = new ProblemService(problemsMock.Object, testsMock.Object, unitOfWorkMock.Object);

            var err = Assert.Throws<NullReferenceException>(() => problemService.GetLeaderboard(null));

            Assert.AreEqual("problem cannot be null", err.Message);
        }

        [Test]
        public void GetLeaderboard_ShouldGetLeaderboard()
        {
            var problemsMock = new Mock<IRepository<Problem>>();
            var testsMock = new Mock<IRepository<Test>>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var problemService = new ProblemService(problemsMock.Object, testsMock.Object, unitOfWorkMock.Object);

            Problem problem = new Problem();
            problem.Id = 2;

            User user1 = new User();
            Submition user1Sub1 = new Submition();
            user1Sub1.ProblemId = 2;
            user1Sub1.CompletedPercentage = 12;
            user1Sub1.Finished = true;

            Submition user1Sub2 = new Submition();
            user1Sub2.ProblemId = 2;
            user1Sub2.CompletedPercentage = 50;
            user1Sub2.Finished = true;

            User user2 = new User();

            user1.Submition.Add(user1Sub1);
            user1.Submition.Add(user1Sub2);

            problem.Users.Add(user1);
            problem.Users.Add(user2);

            IEnumerable<Submition> res = problemService.GetLeaderboard(problem);

            Assert.AreEqual(1, res.Count());
            Assert.AreSame(user1Sub2, res.First());
        }

        [Test]
        public void EditProblem_NullProblem_ShouldReturn()
        {
            //Arrange
            var problemsMock = new Mock<IRepository<Problem>>();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var testsMock = new Mock<IRepository<Test>>();

            var problemService = new ProblemService(problemsMock.Object, testsMock.Object, unitOfWorkMock.Object);

            Problem problem = null;

            int problemId = 2;
            string name = "asd";
            string coverImg = "aasfsd";
            long maxMemory = 123125;
            long maxTime = 51251;
            int xp = 132;
            int testsCount = 1;
            DifficultyType type = DifficultyType.Easy;

            problemsMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(problem);

            List<Test> tests = new List<Test>()
            {
                new Test()
            };

            //Act
            problemService.EditProblem(problemId, name, coverImg, maxMemory, maxTime, xp, testsCount, type, tests);

            //Assert
            unitOfWorkMock.Verify(x => x.Commit(), Times.Never());
        }

        [Test]
        public void EditProblem_ShouldEdit()
        {
            //Arrange
            var problemsMock = new Mock<IRepository<Problem>>();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var testsMock = new Mock<IRepository<Test>>();

            var problemService = new ProblemService(problemsMock.Object, testsMock.Object, unitOfWorkMock.Object);

            Problem problem = new Problem();

            problemsMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(problem);             

            int problemId = 2;
            string name = "asd";
            string coverImg = "aasfsd";
            long maxMemory = 123125;
            long maxTime = 51251;
            int xp = 132;
            int testsCount = 1;
            DifficultyType type = DifficultyType.Easy;

            List<Test> tests = new List<Test>()
            {
                new Test()
            };

            //Act
            problemService.EditProblem(problemId, name, coverImg, maxMemory, maxTime, xp, testsCount, type, tests);

            //Assert
            unitOfWorkMock.Verify(x => x.Commit(), Times.Once());
            problemsMock.Verify(x => x.Update(problem), Times.Once());
        }
    }
}
