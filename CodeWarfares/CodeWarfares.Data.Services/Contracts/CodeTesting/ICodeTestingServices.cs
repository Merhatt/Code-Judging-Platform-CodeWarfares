using CodeWarfares.Data.Services.Enums;
using CodeWarfares.Utils.JsonModels;

namespace CodeWarfares.Data.Services.Contracts.CodeTesting
{
    public interface ICodeTestingServices
    {
        SubmitionModel TestCode(string source, ContestLaungagesTypes laungage, string[] testCases);
    }
}