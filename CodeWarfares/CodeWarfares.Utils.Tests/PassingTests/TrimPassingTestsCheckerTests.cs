using CodeWarfares.Data.Models;
using CodeWarfares.Utils.PassingTests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Utils.Tests.PassingTests
{
    [TestFixture]
    public class TrimPassingTestsCheckerTests
    {
        [Test]
        public void GetPassingTests_ProblemNull_ShouldThrow()
        {
            TrimPassingTestsChecker trimChecker = new TrimPassingTestsChecker();

            var err = Assert.Throws<NullReferenceException>(() => trimChecker.IsPassingTest(null, new TestCompleted()));
            Assert.AreEqual("problem cannot be null", err.Message);
        }

        [Test]
        public void GetPassingTests_TestCompletedNull_ShouldThrow()
        {
            TrimPassingTestsChecker trimChecker = new TrimPassingTestsChecker();

            var err = Assert.Throws<NullReferenceException>(() => trimChecker.IsPassingTest(null, new TestCompleted()));
            Assert.AreEqual("problem cannot be null", err.Message);
        }

        [Test]
        public void GetPassingTests_AllTrueTests_ShouldReturnCorrectAnswer()
        {
            TrimPassingTestsChecker trimChecker = new TrimPassingTestsChecker();

            Problem problem = new Problem();
            problem.TestsCount = 2;
            problem.MaxMemory = 3000000;
            problem.MaxTime = 5;

            Test test = new Test();
            test.CorrectAnswer = "Hello";
            problem.Tests.Add(test);

            Test test2 = new Test();
            test2.CorrectAnswer = "World";
            problem.Tests.Add(test2);

            Submition submition = new Submition();

            TestCompleted testCompleted = new TestCompleted();
            testCompleted.Result = "Hello";
            testCompleted.Time = 2;
            testCompleted.Memory = 1000;
            submition.CompletedTests.Add(testCompleted);

            TestCompleted testCompleted2 = new TestCompleted();
            testCompleted2.Result = "World";
            testCompleted2.Time = 2;
            testCompleted2.Memory = 1000;
            submition.CompletedTests.Add(testCompleted2);

            bool[] res = trimChecker.GetPassingTests(submition, problem);

            Assert.AreEqual(2, res.Length);
            Assert.AreEqual(true, res[0]);
            Assert.AreEqual(true, res[1]);
        }

        [Test]
        public void GetPassingTests_OneTrueOneFalse_ShouldReturnCorrectAnswer()
        {
            TrimPassingTestsChecker trimChecker = new TrimPassingTestsChecker();

            Problem problem = new Problem();
            problem.TestsCount = 2;
            problem.MaxMemory = 3000000;
            problem.MaxTime = 5;

            Test test = new Test();
            test.CorrectAnswer = "Hello";
            problem.Tests.Add(test);

            Test test2 = new Test();
            test2.CorrectAnswer = "World";
            problem.Tests.Add(test2);

            Submition submition = new Submition();

            TestCompleted testCompleted = new TestCompleted();
            testCompleted.Result = "Hello";
            testCompleted.Time = 2;
            testCompleted.Memory = 1000;
            submition.CompletedTests.Add(testCompleted);

            TestCompleted testCompleted2 = new TestCompleted();
            testCompleted2.Result = "Wrong";
            testCompleted2.Time = 2;
            testCompleted2.Memory = 1000;
            submition.CompletedTests.Add(testCompleted2);

            bool[] res = trimChecker.GetPassingTests(submition, problem);

            Assert.AreEqual(2, res.Length);
            Assert.AreEqual(true, res[0]);
            Assert.AreEqual(false, res[1]);
        }

        [Test]
        public void GetPassingTests_AllFalse_ShouldReturnCorrectAnswer()
        {
            TrimPassingTestsChecker trimChecker = new TrimPassingTestsChecker();

            Problem problem = new Problem();
            problem.TestsCount = 2;
            problem.MaxMemory = 3000000;
            problem.MaxTime = 5;

            Test test = new Test();
            test.CorrectAnswer = "Hello";
            problem.Tests.Add(test);

            Test test2 = new Test();
            test2.CorrectAnswer = "World";
            problem.Tests.Add(test2);

            Submition submition = new Submition();

            TestCompleted testCompleted = new TestCompleted();
            testCompleted.Result = "asd";
            testCompleted.Time = 2;
            testCompleted.Memory = 1000;
            submition.CompletedTests.Add(testCompleted);

            TestCompleted testCompleted2 = new TestCompleted();
            testCompleted2.Result = "Wrong";
            testCompleted2.Time = 2;
            testCompleted2.Memory = 1000;
            submition.CompletedTests.Add(testCompleted2);

            bool[] res = trimChecker.GetPassingTests(submition, problem);

            Assert.AreEqual(2, res.Length);
            Assert.AreEqual(false, res[0]);
            Assert.AreEqual(false, res[1]);
        }
    }
}
