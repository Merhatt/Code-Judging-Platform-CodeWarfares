using CodeWarfares.Web.EventArguments;
using CodeWarfares.Web.Presenters.MasterPages;
using CodeWarfares.Web.Views.Contracts.MasterPages;
using CodeWarfares.Web.Views.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Web.Presenters.Tests.MasterPages
{
    [TestFixture]
    public class SiteMasterPresenterTests
    {
        [Test]
        public void Initialize_CookieNotNull()
        {
            var siteMasterViewMock = new Mock<ISiteMaster>();
            string cookie = Guid.NewGuid().ToString("N");

            var model = new SiteMasterModel();

            siteMasterViewMock.SetupGet(x => x.Model).Returns(model);

            SiteMasterPresenter presenter = new SiteMasterPresenter(siteMasterViewMock.Object);
            MasterPageInitEventArgs args = new MasterPageInitEventArgs(cookie);

            presenter.Initialize("asd", args);

            Assert.AreEqual(cookie, model.ViewStateUserKey);
        }

        [Test]
        public void Initialize_CookieNull()
        {
            var siteMasterViewMock = new Mock<ISiteMaster>();
            string cookie = null;

            var model = new SiteMasterModel();

            siteMasterViewMock.SetupGet(x => x.Model).Returns(model);

            SiteMasterPresenter presenter = new SiteMasterPresenter(siteMasterViewMock.Object);

            MasterPageInitEventArgs args = new MasterPageInitEventArgs(cookie);

            presenter.Initialize("asd", args);

            Assert.IsTrue(model.SetCookies);
        }

        [Test]
        public void ValidateTokens_PostBackFalse()
        {
            var siteMasterViewMock = new Mock<ISiteMaster>();
            string viewStateUserKey = "asdasd";

            var identityMock = new Mock<IIdentity>();

            string name = "ivan";
            identityMock.SetupGet(x => x.Name).Returns(name);

            var model = new SiteMasterModel();
            siteMasterViewMock.SetupGet(x => x.Model).Returns(model);

            SiteMasterPresenter presenter = new SiteMasterPresenter(siteMasterViewMock.Object);

            MasterPageValidateTokenEventArgs args = new MasterPageValidateTokenEventArgs(false, viewStateUserKey, name, "asd", "asd");

            presenter.ValidateTokens("asd", args);

            Assert.AreEqual(viewStateUserKey, model.TokenKey);
            Assert.AreEqual(name, model.UserNameKey);
        }

        [Test]
        public void ValidateTokens_PostBackTrue_ShouldThrow()
        {
            var siteMasterViewMock = new Mock<ISiteMaster>();
            string viewStateUserKey = "asdasd";

            var identityMock = new Mock<IIdentity>();

            string name = "ivan";
            identityMock.SetupGet(x => x.Name).Returns(name);

            var model = new SiteMasterModel();
            siteMasterViewMock.SetupGet(x => x.Model).Returns(model);

            SiteMasterPresenter presenter = new SiteMasterPresenter(siteMasterViewMock.Object);
            MasterPageValidateTokenEventArgs args = new MasterPageValidateTokenEventArgs(true, viewStateUserKey, name, "asd", "asd");
            Assert.Throws<InvalidOperationException>(() => presenter.ValidateTokens("asd", args));
        }
    }
}
