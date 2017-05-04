using CodeWarfares.Data.Contracts;
using CodeWarfares.Data.Models;
using CodeWarfares.Data.Services.Account;
using Microsoft.AspNet.Identity.EntityFramework;
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
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            var err = Assert.Throws<NullReferenceException>(() => new UserServices(null, unitOfWorkMock.Object));

            Assert.AreEqual("Users cannot be null", err.Message);
        }

        [Test]
        public void GetAll_ShouldCall()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repoMock = new Mock<IRepository<User>>();

            var qMock = new Mock<IQueryable<User>>();

            repoMock.Setup(x => x.All()).Returns(qMock.Object);

            var services = new UserServices(repoMock.Object, unitOfWorkMock.Object);

            var res = services.GetAll();

            Assert.AreSame(res, qMock.Object);
        }

        [Test]
        public void AssignRole_NullUser_ShouldThrow()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repoMock = new Mock<IRepository<User>>();

            var qMock = new Mock<IQueryable<User>>();

            var user = new User();

            repoMock.Setup(x => x.All()).Returns(qMock.Object);

            var services = new UserServices(repoMock.Object, unitOfWorkMock.Object);

            var err = Assert.Throws<NullReferenceException>(() => services.AssignRole(null, new IdentityUserRole()));

            Assert.AreEqual("user cannot be null", err.Message);
        }

        [Test]
        public void AssignRole_NullRole_ShouldThrow()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repoMock = new Mock<IRepository<User>>();

            var qMock = new Mock<IQueryable<User>>();

            var user = new User();

            repoMock.Setup(x => x.All()).Returns(qMock.Object);

            var services = new UserServices(repoMock.Object, unitOfWorkMock.Object);

            var err = Assert.Throws<NullReferenceException>(() => services.AssignRole(user, null));

            Assert.AreEqual("role cannot be null", err.Message);
        }

        [Test]
        public void AssignRole_ShouldCall()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repoMock = new Mock<IRepository<User>>();

            var qMock = new Mock<IQueryable<User>>();

            var user = new User();

            repoMock.Setup(x => x.All()).Returns(qMock.Object);

            var services = new UserServices(repoMock.Object, unitOfWorkMock.Object);

            var role = new IdentityUserRole();

            services.AssignRole(user, role);

            Assert.AreSame(role, user.Roles.First());
            unitOfWorkMock.Verify(x => x.Commit(), Times.Once());
        }

        [Test]
        public void AddSubmitionToUser_NullUserId_ShouldThrow()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repoMock = new Mock<IRepository<User>>();

            var user = new User();

            string userId = "asd";

            var submition = new Submition();

            repoMock.Setup(x => x.GetById(userId)).Returns(user);

            var services = new UserServices(repoMock.Object, unitOfWorkMock.Object);

            var err = Assert.Throws<NullReferenceException>(() => services.AddSubmitionToUser(null, new Submition()));

            Assert.AreEqual("userId cannot be null", err.Message);
        }

        [Test]
        public void AddSubmitionToUser_NullSubmition_ShouldThrow()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repoMock = new Mock<IRepository<User>>();

            var user = new User();

            string userId = "asd";

            var submition = new Submition();

            repoMock.Setup(x => x.GetById(userId)).Returns(user);

            var services = new UserServices(repoMock.Object, unitOfWorkMock.Object);

            var err = Assert.Throws<NullReferenceException>(() => services.AddSubmitionToUser(userId, null));

            Assert.AreEqual("submition cannot be null", err.Message);
        }

        [Test]
        public void AddSubmitionToUser_ShouldCall()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repoMock = new Mock<IRepository<User>>();

            var user = new User();

            string userId = "asd";

            var submition = new Submition();

            repoMock.Setup(x => x.GetById(userId)).Returns(user);

            var services = new UserServices(repoMock.Object, unitOfWorkMock.Object);

            services.AddSubmitionToUser(userId, submition);

            Assert.AreSame(user.Submition.First(), submition);
            unitOfWorkMock.Verify(x => x.Commit(), Times.Once());
        }

        [Test]
        public void AddProblemToUser_NullUserId_ShouldThrow()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repoMock = new Mock<IRepository<User>>();

            var user = new User();

            string userId = "asd";

            var problem = new Problem();

            repoMock.Setup(x => x.GetById(userId)).Returns(user);

            var services = new UserServices(repoMock.Object, unitOfWorkMock.Object);

            var err = Assert.Throws<NullReferenceException>(() => services.AddProblemToUser(null, new Problem()));

            Assert.AreEqual("userId cannot be null", err.Message);
        }

        [Test]
        public  void AddProblemToUser_NullProblem_ShouldThrow()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repoMock = new Mock<IRepository<User>>();

            var user = new User();

            string userId = "asd";

            var problem = new Problem();

            repoMock.Setup(x => x.GetById(userId)).Returns(user);

            var services = new UserServices(repoMock.Object, unitOfWorkMock.Object);

            var err = Assert.Throws<NullReferenceException>(() => services.AddProblemToUser(userId, null));

            Assert.AreEqual("problem cannot be null", err.Message);
        }

        [Test]
        public void AddProblemToUser_ProblemDontExists_ShouldAdd()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repoMock = new Mock<IRepository<User>>();

            var user = new User();

            string userId = "asd";

            var problem = new Problem();

            problem.Id = 5;

            repoMock.Setup(x => x.GetById(userId)).Returns(user);

            var services = new UserServices(repoMock.Object, unitOfWorkMock.Object);

            services.AddProblemToUser(userId, problem);

            Assert.AreSame(problem, user.Problems.First());
        }

        [Test]
        public void AddProblemToUser_ProblemExists_ShouldNotAdd()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repoMock = new Mock<IRepository<User>>();

            var user = new User();

            string userId = "asd";

            var problem = new Problem();

            problem.Id = 5;

            user.Problems.Add(problem);

            repoMock.Setup(x => x.GetById(userId)).Returns(user);

            var services = new UserServices(repoMock.Object, unitOfWorkMock.Object);

            services.AddProblemToUser(userId, problem);

            Assert.AreEqual(1, user.Problems.Count);
        }

        [Test]
        public void GetByUsername_ShouldGetByUsername()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repoMock = new Mock<IRepository<User>>();

            var user = new User();
            user.UserName = "ivan";

            var user2 = new User();
            user2.UserName = "Dasda";

            var user3 = new User();
            user3.UserName = "kolyo";

            repoMock.Setup(x => x.All()).Returns(new List<User>() { user, user2, user3 }.AsQueryable());

            var services = new UserServices(repoMock.Object, unitOfWorkMock.Object);

            var userReturned = services.GetByUsername("kolyo");

            Assert.AreSame(user3, userReturned);
        }

        [Test]
        public void GetAllUsersWithPoints_ShouldGetWithPoints()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var repoMock = new Mock<IRepository<User>>();

            var user = new User();
            user.UserName = "ivan";

            user.Id = "asd";

            var problem = new Problem();

            problem.Xp = 200;

            var submition = new Submition();

            problem.Submitions.Add(submition);

            submition.AuthorId = user.Id;

            submition.CompletedPercentage = 21;

            var submition2 = new Submition();

            problem.Submitions.Add(submition2);

            submition2.AuthorId = user.Id;

            submition2.CompletedPercentage = 100;

            user.Problems.Add(problem);

            repoMock.Setup(x => x.All()).Returns(new List<User>() { user }.AsQueryable());

            var services = new UserServices(repoMock.Object, unitOfWorkMock.Object);

            var users = services.GetAllUsersWithPoints();

            unitOfWorkMock.Verify(x => x.Commit(), Times.Once());
            Assert.AreEqual(200, user.TotalPoints);
            Assert.AreSame(user, users.First());
        }
    }
}
