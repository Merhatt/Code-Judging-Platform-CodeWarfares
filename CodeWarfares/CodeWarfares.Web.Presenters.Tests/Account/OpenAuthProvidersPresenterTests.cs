using CodeWarfares.Web.EventArguments;
using CodeWarfares.Web.Presenters.Account;
using CodeWarfares.Web.Views.Contracts.Account;
using CodeWarfares.Web.Views.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Web.Presenters.Tests.Account
{
    [TestFixture]
    public class OpenAuthProvidersPresenterTests
    {
        [Test]
        public void Initialization_ShouldNotCallResolve()
        {
            var viewMock = new Mock<IOpenAuthProvidersView>();

            var model = new OpenAuthProvidersModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            OpenAuthProvidersPresenter presenter = new OpenAuthProvidersPresenter(viewMock.Object);
            bool isResolveCalled = false;
            var args = new OpenAuthProvidersInitEventArgs(false, "", "", "", (asd) => { isResolveCalled = true; return ""; });

            viewMock.Raise(x => x.MyInit += null, args);

            Assert.IsFalse(isResolveCalled);
        }

        [Test]
        public void Initialization_ShouldCallResolve()
        {
            var viewMock = new Mock<IOpenAuthProvidersView>();

            var model = new OpenAuthProvidersModel();

            viewMock.SetupGet(x => x.Model).Returns(model);

            OpenAuthProvidersPresenter presenter = new OpenAuthProvidersPresenter(viewMock.Object);
            bool isResolveCalled = false;
            var args = new OpenAuthProvidersInitEventArgs(true, "provider", "providerNameKey", "returnUrl", (asd) => { isResolveCalled = true; return asd; });

            viewMock.Raise(x => x.MyInit += null, args);

            Assert.IsTrue(isResolveCalled);
            Assert.AreEqual(String.Format(CultureInfo.InvariantCulture, "~/Account/RegisterExternalLogin?{0}={1}&returnUrl={2}", args.ProviderNameKey, args.Provider, args.ReturnUrl), presenter.View.Model.RedirectUrl);
        }
    }
}
