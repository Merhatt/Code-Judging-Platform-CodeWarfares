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
        public bool[] GetPassingTests(Submition submition, Problem problem)
        {
            if (submition == null)
            {
                throw new NullReferenceException("Submition cannot be null");
            }
            else if (problem == null)
            {
                throw new NullReferenceException("Problem cannot be null");
            }

            bool[] passingTests = new bool[problem.TestsCount];

            string[] correctAnswers = problem.Tests.Select(t => t.CorrectAnswer).ToArray();

            double maxTime = problem.MaxTime;
            long maxMemory = problem.MaxMemory;

            TestCompleted[] recivedAnswers = submition.CompletedTests.ToArray();

            for (int i = 0; i < problem.TestsCount; i++)
            {
                if (correctAnswers[i].Trim() == recivedAnswers[i].Result.Trim() &&
                    maxTime >= recivedAnswers[i].Time &&
                    maxMemory >= recivedAnswers[i].Memory)
                {
                    passingTests[i] = true;
                }
            }

            return passingTests;
        }
    }
}
