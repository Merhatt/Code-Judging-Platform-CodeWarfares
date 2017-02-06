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
            Assert.Throws<ArgumentNullException>(() => new ProblemService(null));
        }

        [Test]
        public void GetAll_ShouldReturnAll()
        {
            var problemsMock = new Mock<IRepository<Problem>>();
            var queriableMock = new Mock<IQueryable<Problem>>();

            problemsMock.Setup(x => x.All()).Returns(queriableMock.Object);

            var problemService = new ProblemService(problemsMock.Object);

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

            Problem problem2 = new Problem();
            problem2.CreationTime = DateTime.Now;
            problem2.Difficulty = DifficultyType.Hard;

            IQueryable<Problem> problems = null;

            problemsMock.Setup(x => x.All()).Returns(problems);

            var problemService = new ProblemService(problemsMock.Object);

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

            IQueryable<Problem> problems = new List<Problem>().AsQueryable();

            problemsMock.Setup(x => x.All()).Returns(problems);

            var problemService = new ProblemService(problemsMock.Object);

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

            var problems = new List<Problem>()
            {
                problem,
                problem2
            };

            problemsMock.Setup(x => x.All()).Returns(problems.AsQueryable());

            var problemService = new ProblemService(problemsMock.Object);

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

            Problem problem2 = new Problem();
            problem2.CreationTime = DateTime.Now;
            problem2.Difficulty = DifficultyType.Hard;

            var problems = new List<Problem>()
            {
                problem,
                problem2
            };

            problemsMock.Setup(x => x.All()).Returns(problems.AsQueryable());

            var problemService = new ProblemService(problemsMock.Object);

            var problemsRes = problemService.GetAllOrderedByType(DifficultyType.Easy).ToList();

            Assert.AreEqual(1, problemsRes.Count);
            Assert.AreSame(problem, problemsRes[0]);
        }

        [Test]
        public void GetById_ShouldReturnCorrectly()
        {
            var problemsMock = new Mock<IRepository<Problem>>();

            Problem problem = new Problem();

            problemsMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(problem);

            var problemService = new ProblemService(problemsMock.Object);

            var result = problemService.GetById(2);

            Assert.AreSame(problem, result);
        }

        [Test]
        public void Create_NullProblem_ShouldThrow()
        {
            var problemsMock = new Mock<IRepository<Problem>>();

            Problem problem = new Problem();

            problemsMock.Setup(x => x.Add(It.IsAny<Problem>()));

            var problemService = new ProblemService(problemsMock.Object);

            Assert.Throws<ArgumentNullException>(() => problemService.Create(null));
        }

        [Test]
        public void Create_ValdProblem_ShouldCreate()
        {
            var problemsMock = new Mock<IRepository<Problem>>();

            Problem problem = new Problem();

            problemsMock.Setup(x => x.Add(It.IsAny<Problem>()));

            var problemService = new ProblemService(problemsMock.Object);

            problemService.Create(problem);

            problemsMock.Verify(x => x.Add(problem), Times.Once());
            problemsMock.Verify(x => x.SaveChanges(), Times.Once());
        }

        [Test]
        public void DeleteById_ValdProblem_ShouldCreate()
        {
            var problemsMock = new Mock<IRepository<Problem>>();

            Problem problem = new Problem();

            problemsMock.Setup(x => x.Add(It.IsAny<Problem>()));

            var problemService = new ProblemService(problemsMock.Object);

            problemService.DeleteById(2);

            problemsMock.Verify(x => x.Delete(2), Times.Once());
            problemsMock.Verify(x => x.SaveChanges(), Times.Once());
        }

        [Test]
        public void AddSubmitionToProblem_InvaldProblem_ShouldThrow()
        {
            var problemsMock = new Mock<IRepository<Problem>>();

            Problem problem = new Problem();

            problemsMock.Setup(x => x.Add(It.IsAny<Problem>()));

            var problemService = new ProblemService(problemsMock.Object);

            Assert.Throws<ArgumentNullException>(() => problemService.AddSubmitionToProblem(2, null));
        }

        [Test]
        public void AddSubmitionToProblem_CorrectProblem()
        {
            var problemsMock = new Mock<IRepository<Problem>>();

            Problem problem = new Problem();

            problemsMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(problem);

            problemsMock.Setup(x => x.Add(It.IsAny<Problem>()));

            var problemService = new ProblemService(problemsMock.Object);

            var submition = new Submition();

            problemService.AddSubmitionToProblem(2, submition);

            Assert.AreSame(submition, problem.Submitions.First());
            problemsMock.Verify(x => x.SaveChanges(), Times.Once());
        }

        [Test]
        public void GetNewestTopFromCategory_CountLessThanZero_ShouldThrow()
        {
            var problemsMock = new Mock<IRepository<Problem>>();

            Problem problem = new Problem();

            var problemService = new ProblemService(problemsMock.Object);

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

            var problems = new List<Problem>()
            {
                problem,
                problem2
            };

            problemsMock.Setup(x => x.All()).Returns(problems.AsQueryable());

            var problemService = new ProblemService(problemsMock.Object);

            var problemsRes = problemService.GetNewestTopFromCategory(5, DifficultyType.Easy).ToList();

            Assert.AreEqual(1, problemsRes.Count);
            Assert.AreSame(problem, problemsRes[0]);
        }
    }
}
