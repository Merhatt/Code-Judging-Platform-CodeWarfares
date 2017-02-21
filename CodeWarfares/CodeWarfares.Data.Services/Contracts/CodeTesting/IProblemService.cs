using System.Linq;
using CodeWarfares.Data.Models;
using CodeWarfares.Data.Models.Enums;
using System.Collections.Generic;

namespace CodeWarfares.Data.Services.Contracts.CodeTesting
{
    public interface IProblemService
    {
        void AddSubmitionToProblem(int problemId, Submition submition);

        void Create(Problem problem);

        void DeleteById(int id);

        IEnumerable<Problem> GetAll();

        Problem GetById(int id);

        IEnumerable<Problem> GetNewestTopFromCategory(int count, DifficultyType type);

        IEnumerable<Problem> GetAllOrderedByType(DifficultyType type);

        IEnumerable<Submition> GetLeaderboard(Problem problem);
    }
}