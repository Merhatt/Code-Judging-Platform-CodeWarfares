using CodeWarfares.Data.Models.Contracts;
using CodeWarfares.Data.Models.Factories;
using CodeWarfares.Data.Services.Contracts.Account;
using CodeWarfares.Web.Presenters.Account;
using CodeWarfares.Web.Views.Contracts.Account;
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

            Assert.Throws<ArgumentNullException>(() => new RegisterPresenter(view, null));
        }

        [Test]
        public void Register_ShouldSetUserPropertiesCorrectly()
        {
            var mockedIRegisterView = new Mock<IRegisterView>();

            var mockedSignInManager = new Mock<IApplicationSignInManager>();

            var mockedUserManager = new Mock<IApplicationUserManager>();

            mockedIRegisterView.SetupGet(p => p.UserManager).Returns(mockedUserManager.Object);

            mockedIRegisterView.SetupGet(p => p.SignInManager).Returns(mockedSignInManager.Object);

            var mockedIUserFactory = new Mock<IUserFactory>();

            string username = "Ivan";
            string password = "Dragan";
            string email = "test@test.bg";

            var mockedUser = new Mock<IUser>();


            string recivedUsername = "";
            mockedUser.SetupSet(p => p.UserName = It.IsAny<string>())
                .Callback<string>(value => recivedUsername = value);

            string recivedEmail = "";
            mockedUser.SetupSet(p => p.Email = It.IsAny<string>())
                .Callback<string>(value => recivedEmail = value);

            mockedIRegisterView.SetupGet(p => p.Username).Returns(username);
            mockedIRegisterView.SetupGet(p => p.Password).Returns(password);
            mockedIRegisterView.SetupGet(p => p.Email).Returns(email);

            mockedIUserFactory.Setup(f => f.Create()).Returns(mockedUser.Object);

            var registerPresenter = new RegisterPresenter(mockedIRegisterView.Object, mockedIUserFactory.Object);

            registerPresenter.Register();

            Assert.AreEqual(username, recivedUsername);
            Assert.AreEqual(email, recivedEmail);
        }

        [Test]
        public void Register_ShouldCallUserManagerCreateUser()
        {
            var mockedIRegisterView = new Mock<IRegisterView>();

            var mockedSignInManager = new Mock<IApplicationSignInManager>();

            var mockedUserManager = new Mock<IApplicationUserManager>();        

            mockedIRegisterView.SetupGet(p => p.UserManager).Returns(mockedUserManager.Object);

            mockedIRegisterView.SetupGet(p => p.SignInManager).Returns(mockedSignInManager.Object);

            var mockedIUserFactory = new Mock<IUserFactory>();

            string username = "Ivan";
            string password = "Dragan";
            string email = "test@test.bg";

            var mockedUser = new Mock<IUser>();

            mockedUserManager.Setup(x => x.CreateUser(It.IsAny<IUser>(), It.IsAny<string>()))
                                    .Returns(true);


            string recivedUsername = "";
            mockedUser.SetupSet(p => p.UserName = It.IsAny<string>())
                .Callback<string>(value => recivedUsername = value);

            string recivedEmail = "";
            mockedUser.SetupSet(p => p.Email = It.IsAny<string>())
                .Callback<string>(value => recivedEmail = value);

            mockedIRegisterView.SetupGet(p => p.Username).Returns(username);
            mockedIRegisterView.SetupGet(p => p.Password).Returns(password);
            mockedIRegisterView.SetupGet(p => p.Email).Returns(email);

            mockedIUserFactory.Setup(f => f.Create()).Returns(mockedUser.Object);

            var registerPresenter = new RegisterPresenter(mockedIRegisterView.Object, mockedIUserFactory.Object);

            registerPresenter.Register();

            mockedUserManager.Verify(x => x.CreateUser(mockedUser.Object, password), Times.Once());
        }

        [Test]
        public void Register_ShouldCallSignInAndSuccess()
        {
            var mockedIRegisterView = new Mock<IRegisterView>();

            var mockedSignInManager = new Mock<IApplicationSignInManager>();

            var mockedUserManager = new Mock<IApplicationUserManager>();

            mockedIRegisterView.SetupGet(p => p.UserManager).Returns(mockedUserManager.Object);

            mockedIRegisterView.SetupGet(p => p.SignInManager).Returns(mockedSignInManager.Object);

            var mockedIUserFactory = new Mock<IUserFactory>();

            string username = "Ivan";
            string password = "Dragan";
            string email = "test@test.bg";

            var mockedUser = new Mock<IUser>();

            mockedSignInManager.Setup(m => m.SignIn(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>())).Returns(true);

            mockedUserManager.Setup(x => x.CreateUser(It.IsAny<IUser>(), It.IsAny<string>()))
                                    .Returns(true);


            string recivedUsername = "";
            mockedUser.SetupSet(p => p.UserName = It.IsAny<string>())
                .Callback<string>(value => recivedUsername = value);

            string recivedEmail = "";
            mockedUser.SetupSet(p => p.Email = It.IsAny<string>())
                .Callback<string>(value => recivedEmail = value);

            mockedIRegisterView.SetupGet(p => p.Username).Returns(username);
            mockedIRegisterView.SetupGet(p => p.Password).Returns(password);
            mockedIRegisterView.SetupGet(p => p.Email).Returns(email);

            mockedIUserFactory.Setup(f => f.Create()).Returns(mockedUser.Object);

            var registerPresenter = new RegisterPresenter(mockedIRegisterView.Object, mockedIUserFactory.Object);

            registerPresenter.Register();

            mockedSignInManager.Verify(x => x.SignIn(It.IsAny<string>(), password, false, false), Times.Once);
            mockedIRegisterView.Verify(x => x.Success(), Times.Once());
        }

        [Test]
        public void Register_ShouldCallRegisterFailed()
        {
            var mockedIRegisterView = new Mock<IRegisterView>();

            var mockedSignInManager = new Mock<IApplicationSignInManager>();

            var mockedUserManager = new Mock<IApplicationUserManager>();

            mockedIRegisterView.SetupGet(p => p.UserManager).Returns(mockedUserManager.Object);

            mockedIRegisterView.SetupGet(p => p.SignInManager).Returns(mockedSignInManager.Object);

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

            string recivedError = "";
            mockedIRegisterView.SetupSet(p => p.ErrorText = It.IsAny<string>())
                .Callback<string>(value => recivedError = value);

            mockedIRegisterView.SetupGet(p => p.Username).Returns(username);
            mockedIRegisterView.SetupGet(p => p.Password).Returns(password);
            mockedIRegisterView.SetupGet(p => p.Email).Returns(email);

            mockedIUserFactory.Setup(f => f.Create()).Returns(mockedUser.Object);

            var registerPresenter = new RegisterPresenter(mockedIRegisterView.Object, mockedIUserFactory.Object);

            registerPresenter.Register();

            Assert.AreEqual("Cannot register", recivedError);
        }
    }
}
