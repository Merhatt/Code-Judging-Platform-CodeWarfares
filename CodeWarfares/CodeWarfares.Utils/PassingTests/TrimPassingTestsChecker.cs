using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeWarfares.Data.Models;

namespace CodeWarfares.Utils.PassingTests
{
    public class TrimPassingTestsChecker : IPassingTestsChecker
    {
        public bool IsPassingTest(Problem problem, TestCompleted testCompleted)
        {
            if (problem == null)
            {
                throw new NullReferenceException("problem cannot be null");
            }

            if (testCompleted == null)
            {
                throw new NullReferenceException("testCompleted cannot be null");
            }

            bool isTrueAnswer = testCompleted.Result.Trim() == testCompleted.ExpectedResult.Trim() &&
                                testCompleted.Memory <= problem.MaxMemory &&
                                testCompleted.Time <= problem.MaxTime;

            return isTrueAnswer;
        }
    }
}
