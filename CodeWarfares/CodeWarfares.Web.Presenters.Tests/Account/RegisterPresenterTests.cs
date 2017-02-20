using CodeWarfares.Data.Models.Contracts;
using CodeWarfares.Data.Models.Factories;
using CodeWarfares.Data.Services.Contracts.Account;
using CodeWarfares.Web.EventArguments;
using CodeWarfares.Web.Presenters.Account;
using CodeWarfares.Web.Views.Contracts.Account;
using CodeWarfares.Web.Views.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Web.Presenters.Tests.Account
{
    [TestFixture]
    public class RegisterPresenterTests
    {
        [Test]
        public void Constructor_ShouldSetViewCorrectly()
        {
            var mockedIRegisterView = new Mock<IRegisterView>();

            var mockedIUserFactory = new Mock<IUserFactory>();

            var registerPresenter = new RegisterPresenter(mockedIRegisterView.Object, mockedIUserFactory.Object);

            Assert.AreSame(mockedIRegisterView.Object, registerPresenter.View);
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException()
        {
            IRegisterView view = null;
            var userFactoryMock = new Mock<IUserFactory>();

            Assert.Throws<NullReferenceException>(() => new RegisterPresenter(view, userFactoryMock.Object));
        }

        [Test]
        public void Constructor_UserFactoryNull_ShouldThrowArgumentNullException()
        {
            var view = new Mock<IRegisterView>();
            var userFactoryMock = new Mock<IUserFactory>();

            var err = Assert.Throws<NullReferenceException>(() => new RegisterPresenter(view.Object, null));
            Assert.AreEqual("userFactory cannot be null", err.Message);
        }

        [Test]
        public void Register_ShouldSetUserPropertiesCorrectly()
        {
            var mockedIRegisterView = new Mock<IRegisterView>();

            var mockedSignInManager = new Mock<IApplicationSignInManager>();

            var mockedUserManager = new Mock<IApplicationUserManager>();

            var mockedIUserFactory = new Mock<IUserFactory>();

            string username = "Ivan";
            string password = "Dragan";
            string email = "test@test.bg";

            var mockedUser = new Mock<IUser>();

            var model = new RegisterViewModel();

            mockedIRegisterView.SetupGet(x => x.Model).Returns(model);

            string recivedUsername = "";
            mockedUser.SetupSet(p => p.UserName = It.IsAny<string>())
                .Callback<string>(value => recivedUsername = value);

            string recivedEmail = "";
            mockedUser.SetupSet(p => p.Email = It.IsAny<string>())
                .Callback<string>(value => recivedEmail = value);

            mockedIUserFactory.Setup(f => f.Create()).Returns(mockedUser.Object);

            var registerPresenter = new RegisterPresenter(mockedIRegisterView.Object, mockedIUserFactory.Object);

            RegisterEventArgs args = new RegisterEventArgs(mockedUserManager.Object, mockedSignInManager.Object, username, email, password);

            mockedIRegisterView.Raise(x => x.RegisterEvent += null, args);

            Assert.AreEqual(username, recivedUsername);
            Assert.AreEqual(email, recivedEmail);
        }

        [Test]
        public void Register_ShouldCallUserManagerCreateUser()
        {
            var mockedIRegisterView = new Mock<IRegisterView>();

            var mockedSignInManager = new Mock<IApplicationSignInManager>();

            var mockedUserManager = new Mock<IApplicationUserManager>();        

            var mockedIUserFactory = new Mock<IUserFactory>();

            string username = "Ivan";
            string password = "Dragan";
            string email = "test@test.bg";

            var mockedUser = new Mock<IUser>();

            mockedUserManager.Setup(x => x.CreateUser(It.IsAny<IUser>(), It.IsAny<string>()))
                                    .Returns(true);

            var model = new RegisterViewModel();

            mockedIRegisterView.SetupGet(x => x.Model).Returns(model);

            string recivedUsername = "";
            mockedUser.SetupSet(p => p.UserName = It.IsAny<string>())
                .Callback<string>(value => recivedUsername = value);

            string recivedEmail = "";
            mockedUser.SetupSet(p => p.Email = It.IsAny<string>())
                .Callback<string>(value => recivedEmail = value);

            mockedIUserFactory.Setup(f => f.Create()).Returns(mockedUser.Object);

            var registerPresenter = new RegisterPresenter(mockedIRegisterView.Object, mockedIUserFactory.Object);

            RegisterEventArgs args = new RegisterEventArgs(mockedUserManager.Object, mockedSignInManager.Object, username, email, password);

            mockedIRegisterView.Raise(x => x.RegisterEvent += null, args);

            mockedUserManager.Verify(x => x.CreateUser(mockedUser.Object, password), Times.Once());
        }

        [Test]
        public void Register_ShouldCallSignInAndSuccess()
        {
            var mockedIRegisterView = new Mock<IRegisterView>();

            var mockedSignInManager = new Mock<IApplicationSignInManager>();

            var mockedUserManager = new Mock<IApplicationUserManager>();

            var mockedIUserFactory = new Mock<IUserFactory>();

            string username = "Ivan";
            string password = "Dragan";
            string email = "test@test.bg";

            var mockedUser = new Mock<IUser>();

            mockedSignInManager.Setup(m => m.SignIn(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>())).Returns(true);

            mockedUserManager.Setup(x => x.CreateUser(It.IsAny<IUser>(), It.IsAny<string>()))
                                    .Returns(true);

            var model = new RegisterViewModel();

            mockedIRegisterView.SetupGet(x => x.Model).Returns(model);

            string recivedUsername = "";
            mockedUser.SetupSet(p => p.UserName = It.IsAny<string>())
                .Callback<string>(value => recivedUsername = value);

            string recivedEmail = "";
            mockedUser.SetupSet(p => p.Email = It.IsAny<string>())
                .Callback<string>(value => recivedEmail = value);

            mockedIUserFactory.Setup(f => f.Create()).Returns(mockedUser.Object);

            var registerPresenter = new RegisterPresenter(mockedIRegisterView.Object, mockedIUserFactory.Object);

            RegisterEventArgs args = new RegisterEventArgs(mockedUserManager.Object, mockedSignInManager.Object, username, email, password);

            mockedIRegisterView.Raise(x => x.RegisterEvent += null, args);

            mockedSignInManager.Verify(x => x.SignIn(It.IsAny<string>(), password, false, false), Times.Once);
            Assert.IsTrue(model.Success);
        }

        [Test]
        public void Register_ShouldCallRegisterFailed()
        {
            var mockedIRegisterView = new Mock<IRegisterView>();

            var mockedSignInManager = new Mock<IApplicationSignInManager>();

            var mockedUserManager = new Mock<IApplicationUserManager>();

            var mockedIUserFactory = new Mock<IUserFactory>();

            string username = "Ivan";
            string password = "Dragan";
            string email = "test@test.bg";

            var mockedUser = new Mock<IUser>();

            mockedSignInManager.Setup(m => m.SignIn(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>())).Returns(true);

            mockedUserManager.Setup(x => x.CreateUser(It.IsAny<IUser>(), It.IsAny<string>()))
                                    .Returns(false);


            string recivedUsername = "";
            mockedUser.SetupSet(p => p.UserName = It.IsAny<string>())
                .Callback<string>(value => recivedUsername = value);

            string recivedEmail = "";
            mockedUser.SetupSet(p => p.Email = It.IsAny<string>())
                .Callback<string>(value => recivedEmail = value);
            
            var model = new RegisterViewModel();
            mockedIRegisterView.SetupGet(p => p.Model).Returns(model);

            mockedIUserFactory.Setup(f => f.Create()).Returns(mockedUser.Object);

            var registerPresenter = new RegisterPresenter(mockedIRegisterView.Object, mockedIUserFactory.Object);

            RegisterEventArgs args = new RegisterEventArgs(mockedUserManager.Object, mockedSignInManager.Object, username, email, password);

            mockedIRegisterView.Raise(x => x.RegisterEvent += null, args);

            Assert.AreEqual("Cannot register", model.ErrorText);
        }
    }
}
