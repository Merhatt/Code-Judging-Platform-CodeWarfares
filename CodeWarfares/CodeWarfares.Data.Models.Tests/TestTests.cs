using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Models.Tests
{
    [TestFixture]
    public class TestTests
    {
        [Test]
        public void Id_ShouldGetAndSet()
        {
            var test = new Test();

            test.Id = 5;

            Assert.AreEqual(test.Id, 5);
        }

        [Test]
        public void ProblemId_ShouldGetAndSet()
        {
            var test = new Test();

            test.ProblemId = 5;

            Assert.AreEqual(test.ProblemId, 5);
        }

        [Test]
        public void TestParameter_ShouldGetAndSet()
        {
            var test = new Test();

            test.TestParameter = "As";

            Assert.AreEqual(test.TestParameter, "As");
        }

        [Test]
        public void CorrectAnswer_ShouldGetAndSet()
        {
            var test = new Test();

            test.CorrectAnswer = "As";

            Assert.AreEqual(test.CorrectAnswer, "As");
        }

        [Test]
        public void Problem_ShouldGetAndSet()
        {
            var test = new Test();

            var pr = new Problem();

            test.Problem = pr;

            Assert.AreEqual(pr, test.Problem);
        }
    }
}
