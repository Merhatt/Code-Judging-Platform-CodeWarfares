using CodeWarfares.Data.Contracts;
using CodeWarfares.Data.Models;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using System;
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
                throw new ArgumentNullException("problems cannot be null");
            }

            this.problems = problems;
        }

        public IQueryable<Problem> GetAll()
        {
            return this.problems.All();
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
    }
}
