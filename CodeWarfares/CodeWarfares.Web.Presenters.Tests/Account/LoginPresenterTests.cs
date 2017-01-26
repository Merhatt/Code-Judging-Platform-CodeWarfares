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
    public class LoginPresenterTests
    {
        [Test]
        public void Constructor_ShouldSetViewCorrectly()
        {
            var mockedILoginView = new Mock<ILoginView>();

            var loginPresenter = new LoginPresenter(mockedILoginView.Object);

            Assert.AreSame(mockedILoginView.Object, loginPresenter.View);
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException()
        {
            ILoginView view = null;

            Assert.Throws<ArgumentNullException>(() =>  new LoginPresenter(view) );
        }

        [Test]
        public void Initialize_ShouldBeCalledAndShouldSetProperty()
        {
            var mockedILoginView = new Mock<ILoginView>();
            string settedNavigationUrl = "";
            mockedILoginView.SetupSet(p => p.RegisterNavigateUrl = It.IsAny<string>())
                .Callback<string>(value => settedNavigationUrl = value);

            var loginPresenter = new LoginPresenter(mockedILoginView.Object);

            loginPresenter.Initialize();

            Assert.AreEqual("Register", settedNavigationUrl);
        }

        [Test]
        public void SignIn_ShouldCallSuccess()
        {
            var mockedILoginView = new Mock<ILoginView>();

            string username = "Ivan";
            string password = "Dragan";
            bool isPersistent = true;

            var mockedSignInManager = new Mock<IApplicationSignInManager>();

            mockedILoginView.SetupGet(p => p.Username).Returns(username);
            mockedILoginView.SetupGet(p => p.Password).Returns(password);
            mockedILoginView.SetupGet(p => p.ShouldRemember).Returns(isPersistent);

            mockedSignInManager.Setup(m => m.SignIn(username, password, isPersistent, false)).Returns(true);

            mockedILoginView.SetupGet(g => g.AreFieldsValid).Returns(true);

            mockedILoginView.SetupGet(g => g.SignInManager).Returns(mockedSignInManager.Object);

            var loginPresenter = new LoginPresenter(mockedILoginView.Object);

            loginPresenter.SignIn();


            mockedSignInManager.Verify(x => x.SignIn(username, password, isPersistent, false), Times.Once);

            mockedILoginView.Verify(x => x.Success(), Times.Once);
        }

        [Test]
        public void SignIn_InvalidLoginAttempt()
        {
            var mockedILoginView = new Mock<ILoginView>();

            string username = "Ivan";
            string password = "Dragan";
            bool isPersistent = true;

            string errorText = "";
            mockedILoginView.SetupSet(p => p.ErrorText = It.IsAny<string>())
                .Callback<string>(value => errorText = value);

            bool errorVisible = false;
            mockedILoginView.SetupSet(p => p.ErrorTextVisible = It.IsAny<bool>())
                .Callback<bool>(value => errorVisible = value);

            var mockedSignInManager = new Mock<IApplicationSignInManager>();

            mockedILoginView.SetupGet(p => p.Username).Returns(username);
            mockedILoginView.SetupGet(p => p.Password).Returns(password);
            mockedILoginView.SetupGet(p => p.ShouldRemember).Returns(isPersistent);

            mockedSignInManager.Setup(m => m.SignIn(username, password, isPersistent, false)).Returns(false);

            mockedILoginView.SetupGet(g => g.AreFieldsValid).Returns(true);

            mockedILoginView.SetupGet(g => g.SignInManager).Returns(mockedSignInManager.Object);

            var loginPresenter = new LoginPresenter(mockedILoginView.Object);

            loginPresenter.SignIn();


            mockedSignInManager.Verify(x => x.SignIn(username, password, isPersistent, false), Times.Once);

            Assert.AreEqual("Invalid login attempt", errorText);
            Assert.AreEqual(true, errorVisible);
        }
    }
}
