using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Models.Tests
{
    [TestFixture]
    public class SubmitionTests
    {
        [Test]
        public void Id_ShouldGetAndSet()
        {
            var submition = new Submition();

            submition.Id = 5;

            Assert.AreEqual(submition.Id, 5);
        }

        [Test]
        public void TestCounts_ShouldGetAndSet()
        {
            var submition = new Submition();

            submition.TestCounts = 5;

            Assert.AreEqual(submition.TestCounts, 5);
        }

        [Test]
        public void ProblemId_ShouldGetAndSet()
        {
            var submition = new Submition();

            submition.ProblemId = 5;

            Assert.AreEqual(submition.ProblemId, 5);
        }

        [Test]
        public void Finished_ShouldGetAndSet()
        {
            var submition = new Submition();

            submition.Finished = true;

            Assert.AreEqual(submition.Finished, true);
        }

        [Test]
        public void CanCompile_ShouldGetAndSet()
        {
            var submition = new Submition();

            submition.CanCompile = true;

            Assert.AreEqual(submition.CanCompile, true);
        }

        [Test]
        public void Code_ShouldGetAndSet()
        {
            var submition = new Submition();

            submition.Code = "ASD";

            Assert.AreEqual(submition.Code, "ASD");
        }

        [Test]
        public void CompileMessage_ShouldGetAndSet()
        {
            var submition = new Submition();

            submition.CompileMessage = "ASD";

            Assert.AreEqual(submition.CompileMessage, "ASD");
        }

        [Test]
        public void AuthorId_ShouldGetAndSet()
        {
            var submition = new Submition();

            submition.AuthorId = "ASD";

            Assert.AreEqual(submition.AuthorId, "ASD");
        }

        [Test]
        public void SubmitionTime_ShouldGetAndSet()
        {
            var submition = new Submition();

            var date = new DateTime();

            submition.SubmitionTime = date;

            Assert.AreEqual(submition.SubmitionTime, date);
        }

        [Test]
        public void CompletedTests_ShouldGetAndSet()
        {
            var submition = new Submition();

            var ct = new TestCompleted();

            submition.CompletedTests.Add(ct);

            Assert.AreEqual(submition.CompletedTests.First(), ct);
        }

        [Test]
        public void Problem_ShouldGetAndSet()
        {
            var submition = new Submition();

            var pr = new Problem();

            submition.Problem = pr;

            Assert.AreSame(pr, submition.Problem);
        }

        [Test]
        public void User_ShouldGetAndSet()
        {
            var submition = new Submition();

            var pr = new User();

            submition.Author = pr;

            Assert.AreSame(pr, submition.Author);
        }
    }
}
