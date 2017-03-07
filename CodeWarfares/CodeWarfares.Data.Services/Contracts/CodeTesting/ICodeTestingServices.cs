using CodeWarfares.Data.Models;
using CodeWarfares.Data.Services.Enums;
using CodeWarfares.Utils.JsonModels;
using System.Collections.Generic;

namespace CodeWarfares.Data.Services.Contracts.CodeTesting
{
    public interface ICodeTestingServices
    {
        /// <summary>
        /// Tests code in given laungage with testcase
        /// </summary>
        /// <param name="source"></param>
        /// <param name="laungage"></param>
        /// <param name="testCase"></param>
        /// <returns></returns>
        string TestCode(string source, ContestLaungagesTypes laungage, string testCase);

        /// <summary>
        /// Gets if all tests has result.
        /// </summary>
        /// <param name="problem"></param>
        /// <param name="submition"></param>
        /// <returns></returns>
        bool GetAreAllTestsCompleted(Problem problem, Submition submition);
    }
}