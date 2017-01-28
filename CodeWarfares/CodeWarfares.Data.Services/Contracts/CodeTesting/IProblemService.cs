using System.Linq;
using CodeWarfares.Data.Models;

namespace CodeWarfares.Data.Services.Contracts.CodeTesting
{
    public interface IProblemService
    {
        void AddSubmitionToProblem(int problemId, Submition submition);
        void Create(Problem problem);
        void DeleteById(int id);
        IQueryable<Problem> GetAll();
        Problem GetById(int id);
    }
}