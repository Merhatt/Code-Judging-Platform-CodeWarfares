using CodeWarfares.Data.Models;

namespace CodeWarfares.Data.Services.Contracts.CodeTesting
{
    public interface ICodeSubmitionService
    {
        void SendSubmition(User user, Problem problem, string source);
    }
}