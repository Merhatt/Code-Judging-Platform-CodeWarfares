using System.Linq;
using CodeWarfares.Data.Models;
using CodeWarfares.Data.Models.Enums;
using System.Collections.Generic;

namespace CodeWarfares.Data.Services.Contracts.CodeTesting
{
    public interface IProblemService
    {
        /// <summary>
        /// Adds submition to problem
        /// </summary>
        /// <param name="problemId"></param>
        /// <param name="submition"></param>
        void AddSubmitionToProblem(int problemId, Submition submition);

        /// <summary>
        /// Creates problem in database
        /// </summary>
        /// <param name="problem"></param>
        void Create(Problem problem);

        /// <summary>
        /// Gets all problems
        /// </summary>
        /// <returns></returns>
        IQueryable<Problem> GetAll();

        /// <summary>
        /// Gets problem by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Problem GetById(int id);

        /// <summary>
        /// Gets newest top problems from dificulty category
        /// </summary>
        /// <param name="count"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        IQueryable<Problem> GetNewestTopFromCategory(int count, DifficultyType type);

        /// <summary>
        /// Gets all problem ordered by type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IQueryable<Problem> GetAllOrderedByType(DifficultyType type);

        /// <summary>
        /// Gets leaderboard for problem
        /// </summary>
        /// <param name="problem"></param>
        /// <returns></returns>
        IEnumerable<Submition> GetLeaderboard(Problem problem);

        void EditProblem(int problemId, string name, string coverImg, long maxMemory, long maxTime, int xp, int testsCount, DifficultyType dificulty, IEnumerable<Test> tests);

        void DeleteProblem(int problemId);
    }
}