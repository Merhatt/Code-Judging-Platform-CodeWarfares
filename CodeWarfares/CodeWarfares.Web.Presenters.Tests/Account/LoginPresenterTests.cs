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

            Assert.Throws<NullReferenceException>(() => new LoginPresenter(view));
        }

        [Test]
        public void Initialize_ShouldBeCalledAndShouldSetProperty()
        {
            var mockedILoginView = new Mock<ILoginView>();
            var model = new LoginViewModel();
            mockedILoginView.SetupGet(p => p.Model).Returns(model);

            var loginPresenter = new LoginPresenter(mockedILoginView.Object);

            mockedILoginView.Raise(x => x.MyInit += null, new EventArgs());

            Assert.AreEqual("Register", model.RegisterNavigateUrl);
        }

        [Test]
        public void SignIn_ShouldCallSuccess()
        {
            var mockedILoginView = new Mock<ILoginView>();

            string username = "Ivan";
            string password = "Dragan";
            bool isPersistent = true;


            var mockedSignInManager = new Mock<IApplicationSignInManager>();

            SignInEventArgs args = new SignInEventArgs(true, mockedSignInManager.Object, username, password, isPersistent);

            mockedSignInManager.Setup(m => m.SignIn(username, password, isPersistent, false)).Returns(true);

            var model = new LoginViewModel();

            mockedILoginView.SetupGet(x => x.Model).Returns(model);

            var loginPresenter = new LoginPresenter(mockedILoginView.Object);

            mockedILoginView.Raise(x => x.SignInEvent += null, args);

            mockedSignInManager.Verify(x => x.SignIn(username, password, isPersistent, false), Times.Once);
            Assert.IsTrue(model.IsSignedIn);
        }

        [Test]
        public void SignIn_InvalidLoginAttempt()
        {
            var mockedILoginView = new Mock<ILoginView>();

            string username = "Ivan";
            string password = "Dragan";
            bool isPersistent = true;

            var model = new LoginViewModel();

            mockedILoginView.SetupGet(x => x.Model).Returns(model);

            var mockedSignInManager = new Mock<IApplicationSignInManager>();

            mockedSignInManager.Setup(m => m.SignIn(username, password, isPersistent, false)).Returns(false);

            SignInEventArgs args = new SignInEventArgs(true, mockedSignInManager.Object, username, password, isPersistent);

            var loginPresenter = new LoginPresenter(mockedILoginView.Object);

            mockedILoginView.Raise(x => x.SignInEvent += null, args);

            mockedSignInManager.Verify(x => x.SignIn(username, password, isPersistent, false), Times.Once);

            Assert.AreEqual("Invalid login attempt", model.ErrorText);
            Assert.AreEqual(true, model.ErrorTextVisible);
        }
    }
}
