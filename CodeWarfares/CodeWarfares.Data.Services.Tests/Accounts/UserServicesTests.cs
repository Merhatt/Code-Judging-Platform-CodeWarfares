using CodeWarfares.Data.Contracts;
using CodeWarfares.Data.Models;
using CodeWarfares.Data.Services.Account;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Services.Tests.Accounts
{
    [TestFixture]
    public class UserServicesTests
    {
        [Test]
        public void Constructor_NullRepository_ShouldThrow()
        {
            Assert.Throws<ArgumentNullException>(() => new UserServices(null));
        }

        [Test]
        public void GetAll_ShouldCall()
        {
            var repoMock = new Mock<IRepository<User>>();

            var qMock = new Mock<IQueryable<User>>();

            repoMock.Setup(x => x.All()).Returns(qMock.Object);

            var services = new UserServices(repoMock.Object);

            var res = services.GetAll();

            Assert.AreSame(res, qMock.Object);
        }

        [Test]
        public void AssignRole_NullUser_ShouldThrow()
        {
            var repoMock = new Mock<IRepository<User>>();

            var qMock = new Mock<IQueryable<User>>();

            var user = new User();

            repoMock.Setup(x => x.All()).Returns(qMock.Object);

            var services = new UserServices(repoMock.Object);

            Assert.Throws<ArgumentNullException>(() => services.AssignRole(null, null));
        }

        [Test]
        public void AssignRole_ShouldCall()
        {
            var repoMock = new Mock<IRepository<User>>();

            var qMock = new Mock<IQueryable<User>>();

            var user = new User();

            repoMock.Setup(x => x.All()).Returns(qMock.Object);

            var services = new UserServices(repoMock.Object);

            services.AssignRole(user, null);

            Assert.AreEqual(user.Roles.First(), null);
            repoMock.Verify(x => x.SaveChanges(), Times.Once());
        }

        [Test]
        public void AddSubmitionToUser_NullSubmition_ShouldThrow()
        {
            var repoMock = new Mock<IRepository<User>>();

            var user = new User();

            string userId = "asd";

            var submition = new Submition();

            repoMock.Setup(x => x.GetById(userId)).Returns(user);

            var services = new UserServices(repoMock.Object);

            Assert.Throws<ArgumentNullException>(() => services.AddSubmitionToUser(userId, null));
        }

        [Test]
        public void AddSubmitionToUser_ShouldCall()
        {
            var repoMock = new Mock<IRepository<User>>();

            var user = new User();

            string userId = "asd";

            var submition = new Submition();

            repoMock.Setup(x => x.GetById(userId)).Returns(user);

            var services = new UserServices(repoMock.Object);

            services.AddSubmitionToUser(userId, submition);

            Assert.AreSame(user.Submition.First(), submition);
            repoMock.Verify(x => x.SaveChanges(), Times.Once());
        }

        [Test]
        public  void AddProblemToUser_NullProblem_ShouldThrow()
        {
            var repoMock = new Mock<IRepository<User>>();

            var user = new User();

            string userId = "asd";

            var problem = new Problem();

            repoMock.Setup(x => x.GetById(userId)).Returns(user);

            var services = new UserServices(repoMock.Object);

            Assert.Throws<ArgumentNullException>(() => services.AddProblemToUser(userId, null));
        }

        [Test]
        public void AddProblemToUser_ProblemDontExists_ShouldAdd()
        {
            var repoMock = new Mock<IRepository<User>>();

            var user = new User();

            string userId = "asd";

            var problem = new Problem();

            problem.Id = 5;

            repoMock.Setup(x => x.GetById(userId)).Returns(user);

            var services = new UserServices(repoMock.Object);

            services.AddProblemToUser(userId, problem);

            Assert.AreSame(problem, user.Problems.First());
        }

        [Test]
        public void AddProblemToUser_ProblemExists_ShouldNotAdd()
        {
            var repoMock = new Mock<IRepository<User>>();

            var user = new User();

            string userId = "asd";

            var problem = new Problem();

            problem.Id = 5;

            user.Problems.Add(problem);

            repoMock.Setup(x => x.GetById(userId)).Returns(user);

            var services = new UserServices(repoMock.Object);

            services.AddProblemToUser(userId, problem);

            Assert.AreEqual(1, user.Problems.Count);
        }
    }
}
