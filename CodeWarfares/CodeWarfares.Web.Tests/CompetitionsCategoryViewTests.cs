using CodeWarfares.Data.Models;
using CodeWarfares.Web.Codings;
using CodeWarfares.Web.Views.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CodeWarfares.Web.Tests
{
    [TestFixture]
    public class CompetitionsCategoryViewTests
    {
        [Test]
        public void Page_Load_ShouldThrow()
        {
            var view = new CompetitionsCategory();

            view.Model = new CompetitionsCategoryViewModel();
           
            Assert.Throws<HttpException>(() => view.Page_Load("Sender", new EventArgs()));
        }
    }
}
