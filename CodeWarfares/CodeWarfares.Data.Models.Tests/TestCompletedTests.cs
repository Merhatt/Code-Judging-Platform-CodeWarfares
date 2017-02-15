using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Models.Tests
{
    [TestFixture]
    public class TestCompletedTests
    {
        [Test]
        public void TestAllProperties()
        {
            var test = new TestCompleted();
            int id = 5;
            string result = "res";
            bool error = true;
            bool correct = false;
            double time = 2;
            long memory = 1;
            int submitionId = 2;
            Submition sub = new Submition();

            test.Id = id;
            test.Memory = memory;
            test.Result = result;
            test.Submition = sub;
            test.SubmitionId = submitionId;
            test.Time = time;
            test.Error = error;
            test.IsCorrect = correct;

            Assert.AreEqual(test.Id, id);
            Assert.AreEqual(test.Memory, memory);
            Assert.AreSame(test.Submition, sub);
            Assert.AreEqual(test.SubmitionId, submitionId);
            Assert.AreEqual(test.Time, time);
            Assert.AreEqual(test.Error, error);
            Assert.AreEqual(test.IsCorrect, correct);
            Assert.AreEqual(test.Result, result);
        }
    }
}
