using System.Linq;
using CodeWarfares.Data.Models;
using CodeWarfares.Data.Models.Enums;

namespace CodeWarfares.Data.Services.Contracts.CodeTesting
{
    public interface IProblemService
    {
        void AddSubmitionToProblem(int problemId, Submition submition);
        void Create(Problem problem);
        void DeleteById(int id);
        IQueryable<Problem> GetAll();
        Problem GetById(int id);
        IQueryable<Problem> GetNewestTopFromCategory(int count, DifficultyType type);
    }
}