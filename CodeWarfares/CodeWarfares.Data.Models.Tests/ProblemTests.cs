using CodeWarfares.Data.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Models.Tests
{
    [TestFixture]
    public class ProblemTests
    {
        [Test]
        public void Id_ShouldGetAndSet()
        {
            var problem = new Problem();

            problem.Id = 5;

            Assert.AreEqual(problem.Id, 5);
        }

        [Test]
        public void Name_ShouldGetAndSet()
        {
            var problem = new Problem();

            problem.Name = "Hi";

            Assert.AreEqual(problem.Name, "Hi");
        }

        [Test]
        public void MaxMemory_ShouldGetAndSet()
        {
            var problem = new Problem();

            problem.MaxMemory = 3;

            Assert.AreEqual(problem.MaxMemory, 3);
        }

        [Test]
        public void MaxTime_ShouldGetAndSet()
        {
            var problem = new Problem();

            problem.MaxTime = 3;

            Assert.AreEqual(problem.MaxTime, 3);
        }

        [Test]
        public void TestsCount_ShouldGetAndSet()
        {
            var problem = new Problem();

            problem.TestsCount = 3;

            Assert.AreEqual(problem.TestsCount, 3);
        }

        [Test]
        public void Submitions_ShouldGetAndSet()
        {
            var problem = new Problem();

            var subm = new Submition();

            problem.Submitions.Add(subm);

            problem.TestsCount = 3;

            Assert.AreSame(subm, problem.Submitions.First());
        }

        [Test]
        public void Tests_ShouldGetAndSet()
        {
            var problem = new Problem();

            var subm = new Test();

            problem.Tests.Add(subm);

            Assert.AreSame(subm, problem.Tests.First());
        }

        [Test]
        public void ShouldGetAndSetAll()
        {
            var problem = new Problem();

            problem.CoverImageUrl = "asd";
            problem.Submitions = new List<Submition>() { new Submition() };
            problem.Tests = new List<Test>() { new Test() };
            problem.Users = new List<User>() { new User() };

            Assert.AreEqual("asd", problem.CoverImageUrl);
            Assert.AreEqual(1, problem.Submitions.Count);
            Assert.AreEqual(1, problem.Tests.Count);
            Assert.AreEqual(1, problem.Users.Count);
        }
    }
}
