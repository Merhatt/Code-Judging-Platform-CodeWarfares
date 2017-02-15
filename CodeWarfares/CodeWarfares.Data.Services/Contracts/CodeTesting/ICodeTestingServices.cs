using CodeWarfares.Data.Models;
using CodeWarfares.Data.Services.Enums;
using CodeWarfares.Utils.JsonModels;
using System.Collections.Generic;

namespace CodeWarfares.Data.Services.Contracts.CodeTesting
{
    public interface ICodeTestingServices
    {
        string TestCode(string source, ContestLaungagesTypes laungage, string testCase);

        bool GetAreAllTestsCompleted(Problem problem, Submition submition);
    }
}