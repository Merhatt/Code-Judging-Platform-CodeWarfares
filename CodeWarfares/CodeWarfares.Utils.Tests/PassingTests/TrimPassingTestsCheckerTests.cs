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

            var err = Assert.Throws<NullReferenceException>(() => trimChecker.IsPassingTest(new Problem(), null));
            Assert.AreEqual("testCompleted cannot be null", err.Message);
        }

        [Test]
        public void GetPassingTests_AllCorrect_ShouldReturnCorrectAnswer()
        {
            TrimPassingTestsChecker trimChecker = new TrimPassingTestsChecker();

            var problem = new Problem();
            var testCompleted = new TestCompleted();

            problem.MaxMemory = 1000;
            problem.MaxTime = 1000;

            testCompleted.Result = "   asd   ";
            testCompleted.ExpectedResult = "asd";
            testCompleted.Memory = 500;
            testCompleted.Time = 500;

            bool isPassing = trimChecker.IsPassingTest(problem, testCompleted);

            Assert.IsTrue(isPassing);
        }

        [Test]
        public void GetPassingTests_WrongResult_ShouldReturnCorrectAnswer()
        {
            TrimPassingTestsChecker trimChecker = new TrimPassingTestsChecker();

            var problem = new Problem();
            var testCompleted = new TestCompleted();

            problem.MaxMemory = 1000;
            problem.MaxTime = 1000;

            testCompleted.Result = "   asdd   ";
            testCompleted.ExpectedResult = "asd";
            testCompleted.Memory = 500;
            testCompleted.Time = 500;

            bool isPassing = trimChecker.IsPassingTest(problem, testCompleted);

            Assert.IsFalse(isPassing);
        }

        [Test]
        public void GetPassingTests_WrongMemory_ShouldReturnCorrectAnswer()
        {
            TrimPassingTestsChecker trimChecker = new TrimPassingTestsChecker();

            var problem = new Problem();
            var testCompleted = new TestCompleted();

            problem.MaxMemory = 1000;
            problem.MaxTime = 1000;

            testCompleted.Result = "   asd   ";
            testCompleted.ExpectedResult = "asd";
            testCompleted.Memory = 1200;
            testCompleted.Time = 500;

            bool isPassing = trimChecker.IsPassingTest(problem, testCompleted);

            Assert.IsFalse(isPassing);
        }

        [Test]
        public void GetPassingTests_WrongTime_ShouldReturnCorrectAnswer()
        {
            TrimPassingTestsChecker trimChecker = new TrimPassingTestsChecker();

            var problem = new Problem();
            var testCompleted = new TestCompleted();

            problem.MaxMemory = 1000;
            problem.MaxTime = 1000;

            testCompleted.Result = "   asd   ";
            testCompleted.ExpectedResult = "asd";
            testCompleted.Memory = 500;
            testCompleted.Time = 1200;

            bool isPassing = trimChecker.IsPassingTest(problem, testCompleted);

            Assert.IsFalse(isPassing);
        }
    }
}
