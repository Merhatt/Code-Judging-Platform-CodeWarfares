using CodeWarfares.Data.Contracts;
using CodeWarfares.Data.Models;
using CodeWarfares.Data.Models.Enums;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarfares.Data.Services.CodeTesting
{
    public class ProblemService : IProblemService
    {
        private IRepository<Problem> problems;

        public ProblemService(IRepository<Problem> problems)
        {
            if (problems == null)
            {
                throw new NullReferenceException("problems cannot be null");
            }

            this.problems = problems;
        }

        public IQueryable<Problem> GetAll()
        {
            return this.problems.All();
        }

        public IQueryable<Problem> GetAllOrderedByType(DifficultyType type)
        {
            var problemsAll = this.problems.All();

            if (problemsAll == null || problemsAll.Count() == 0)
            {
                return new List<Problem>().AsQueryable();
            }

            problemsAll = problemsAll.Where(x => x.Difficulty == type);

            if (problemsAll == null || problemsAll.Count() == 0)
            {
                return new List<Problem>().AsQueryable();
            }

            return problemsAll.OrderBy(x => x.CreationTime);
        }

        public IQueryable<Problem> GetNewestTopFromCategory(int count, DifficultyType type)
        {
            if (count < 0)
            {
                throw new ArgumentException("count cannot be less than 0!");
            }

            return this.problems.All().Where(x => x.Difficulty == type).OrderBy(x => x.CreationTime).Take(count);
        }

        public Problem GetById(int id)
        {
            return this.problems.GetById(id);
        }

        public void Create(Problem problem)
        {
            if (problem == null)
            {
                throw new ArgumentNullException("Problem cannot be null");
            }

            this.problems.Add(problem);
            this.problems.SaveChanges();
        }

        public void DeleteById(int id)
        {
            this.problems.Delete(id);
            this.problems.SaveChanges();
        }

        public void AddSubmitionToProblem(int problemId, Submition submition)
        {
            if (submition == null)
            {
                throw new ArgumentNullException("submition cannot be null");
            }

            this.problems.GetById(problemId).Submitions.Add(submition);
            this.problems.SaveChanges();
        }

        public IEnumerable<Submition> GetLeaderboard(Problem problem)
        {
            if (problem == null)
            {
                throw new NullReferenceException("problem cannot be null");
            }

            IList<User> users = problem.Users.ToList();

            ICollection<Submition> leaderboard = new List<Submition>();

            foreach (User user in users)
            {
                IEnumerable<Submition> userSubmitions = user.Submition.Where(s => s.ProblemId == problem.Id &&
                                s.Finished);

                if (userSubmitions == null || userSubmitions.Count() == 0)
                {
                    continue;
                }

                Submition submition = userSubmitions.OrderByDescending(s => s.CompletedPercentage).FirstOrDefault();

                leaderboard.Add(submition);
            }

            return leaderboard.OrderByDescending(x => x.CompletedPercentage);
        }
    }
}
