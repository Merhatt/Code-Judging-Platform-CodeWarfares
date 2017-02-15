using CodeWarfares.Data.Models;
using CodeWarfares.Data.Services.Enums;
using System.Collections.Generic;

namespace CodeWarfares.Data.Services.Contracts.CodeTesting
{
    public interface ICodeSubmitionService
    {
        void SendSubmition(User user, Problem problem, string source, ContestLaungagesTypes laungage);

        IEnumerable<Submition> GetAllUserSubmition(User user, Problem problem);
    }
}