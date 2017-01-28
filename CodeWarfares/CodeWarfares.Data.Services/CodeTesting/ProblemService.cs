using CodeWarfares.Data.Contracts;
using CodeWarfares.Data.Models;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using System.Linq;

namespace CodeWarfares.Data.Services.CodeTesting
{
    public class ProblemService : IProblemService
    {
        private IRepository<Problem> problems;

        public ProblemService(IRepository<Problem> problems)
        {
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
            this.problems.GetById(problemId).Submition.Add(submition);
            this.problems.SaveChanges();
        }
    }
}
