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
    public class CompetitionProblemViewModelTests
    {
        [Test]
        public void TestAllProperties()
        {
            var model = new CompetitionProblemViewModel();
            model.Problem = new Problem();
            model.ProblemPath = "hello";
            model.ProblemTitle = "title";
            model.ProgrammingLaungages = new List<string>();
            model.UserSubmitions = new List<Submition>();

            Assert.IsNotNull(model.Problem);
            Assert.AreEqual("hello", model.ProblemPath);
            Assert.AreEqual("title", model.ProblemTitle);
            Assert.IsNotNull(model.ProgrammingLaungages);
            Assert.IsNotNull(model.UserSubmitions);
        }
    }
}
