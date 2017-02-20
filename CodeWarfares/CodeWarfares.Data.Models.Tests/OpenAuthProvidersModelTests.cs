using CodeWarfares.Web.Views.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Models.Tests
{
    [TestFixture]
    public class OpenAuthProvidersModelTests
    {
        [Test]
        public void TestAllProperties()
        {
            var model = new OpenAuthProvidersModel();
            model.Completed = true;
            model.RedirectUrl = "asd";
            model.StatusUrl = 5;

            Assert.AreEqual(true, model.Completed);
            Assert.AreEqual(5, model.StatusUrl);
            Assert.AreEqual("asd", model.RedirectUrl);
        }
    }
}
