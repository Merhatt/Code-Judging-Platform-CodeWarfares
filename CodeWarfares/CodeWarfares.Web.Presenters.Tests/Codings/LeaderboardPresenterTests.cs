using CodeWarfares.Data.Models;
using CodeWarfares.Data.Services.Contracts.Account;
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
    public class LeaderboardPresenterTests
    {
        [Test]
        public void Constructor_NullUserServices_ShouldThrow()
        {
            var viewMock = new Mock<ILeaderboardView>();

            var err = Assert.Throws<NullReferenceException>(() => new LeaderboardPresenter(viewMock.Object, null));

            Assert.AreEqual("userServices cannot be null", err.Message);
        }

        [Test]
        public void Initialize_ShouldSetLeaderboard()
        {
            var viewMock = new Mock<ILeaderboardView>();
            var userServiceMock = new Mock<IUserServices>();

            var users = new List<User>() { new User() };

            userServiceMock.Setup(x => x.GetAllUsersWithPoints()).Returns(users);

            var model = new LeaderboardModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            var presenter = new LeaderboardPresenter(viewMock.Object, userServiceMock.Object);

            viewMock.Raise(x => x.MyInit += null, new EventArgs());

            userServiceMock.Verify(x => x.GetAllUsersWithPoints(), Times.Once());

            Assert.AreEqual(users, model.Leaderboard);
        }
    }
}
