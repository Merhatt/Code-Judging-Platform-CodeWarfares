using CodeWarfares.Web.Presenters.MasterPages;
using CodeWarfares.Web.Views.Contracts.MasterPages;
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
            
            siteMasterViewMock.SetupSet(x => x.ViewStateUserKey = cookie).Verifiable();

            siteMasterViewMock.SetupGet(x => x.Cookie).Returns(cookie);

            SiteMasterPresenter presenter = new SiteMasterPresenter(siteMasterViewMock.Object);

            presenter.Initialize();

            siteMasterViewMock.Verify();
        }

        [Test]
        public void Initialize_CookieNull()
        {
            var siteMasterViewMock = new Mock<ISiteMaster>();
            string cookie = null;

            siteMasterViewMock.SetupSet(x => x.ViewStateUserKey = cookie).Verifiable();

            SiteMasterPresenter presenter = new SiteMasterPresenter(siteMasterViewMock.Object);

            bool eventRaised = false;

            presenter.SetResponseCookieEvent += (object obj, EventArgs e) => 
            { eventRaised = true; };

            presenter.Initialize();

            Assert.AreEqual(true, eventRaised);
        }

        [Test]
        public void ValidateTokens_PostBackFalse()
        {
            var siteMasterViewMock = new Mock<ISiteMaster>();
            string viewStateUserKey = "asdasd";

            var identityMock = new Mock<IIdentity>();

            string name = "ivan";
            identityMock.SetupGet(x => x.Name).Returns(name);

            siteMasterViewMock.SetupGet(x => x.Identity).Returns(identityMock.Object);

            siteMasterViewMock.SetupGet(x => x.IsPostBack).Returns(false);

            siteMasterViewMock.SetupGet(x => x.ViewStateUserKey).Returns(viewStateUserKey);

            siteMasterViewMock.SetupSet(x => x.TokenKey = viewStateUserKey).Verifiable();

            siteMasterViewMock.SetupSet(x => x.UserNameKey = name).Verifiable();

            SiteMasterPresenter presenter = new SiteMasterPresenter(siteMasterViewMock.Object);         

            presenter.ValidateTokens();

            siteMasterViewMock.Verify();
        }

        [Test]
        public void ValidateTokens_PostBackTrue_ShouldThrow()
        {
            var siteMasterViewMock = new Mock<ISiteMaster>();
            string viewStateUserKey = "asdasd";

            var identityMock = new Mock<IIdentity>();

            string name = "ivan";
            identityMock.SetupGet(x => x.Name).Returns(name);

            siteMasterViewMock.SetupGet(x => x.Identity).Returns(identityMock.Object);

            siteMasterViewMock.SetupGet(x => x.TokenKey).Returns("not same");

            siteMasterViewMock.SetupGet(x => x.IsPostBack).Returns(true);

            siteMasterViewMock.SetupGet(x => x.ViewStateUserKey).Returns(viewStateUserKey);

            siteMasterViewMock.SetupSet(x => x.TokenKey = viewStateUserKey).Verifiable();

            siteMasterViewMock.SetupSet(x => x.UserNameKey = name).Verifiable();

            SiteMasterPresenter presenter = new SiteMasterPresenter(siteMasterViewMock.Object);

            Assert.Throws<InvalidOperationException>(() => presenter.ValidateTokens());
        }
    }
}
