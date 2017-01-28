using CodeWarfares.Data.Contracts;
using CodeWarfares.Data.Models;
using CodeWarfares.Data.Models.Factories;
using CodeWarfares.Data.Services.Contracts.Account;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using CodeWarfares.Data.Services.Enums;
using CodeWarfares.Utils.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Services.CodeTesting
{
    public class CodeSubmitionService : ICodeSubmitionService
    {
        private ICodeTestingServices codeTestingService;
        private ISubmitionFactory submitionFactory;
        private IUserServices userService;
        private IProblemService problemService;
        private IRepository<Submition> submitions;

        public CodeSubmitionService(IRepository<Submition> submitions, ICodeTestingServices codeTestingService, ISubmitionFactory submitionFactory)
        {
            this.codeTestingService = codeTestingService;
            this.submitionFactory = submitionFactory;
            this.submitions = submitions;
        }

        public void Create(Submition submition)
        {
            this.submitions.Add(submition);
            this.submitions.SaveChanges();
        }

        public void SendSubmition(User user, Problem problem, string source, ContestLaungagesTypes laungage)
        {
            Submition submition = this.submitionFactory.Create();
            submition.Code = source;
            submition.Author = user;
            submition.Problem = problem;
            submition.TestCounts = problem.TestsCount;
            submition.Compiled = false;
            submition.Author = user;
            submition.Problem = problem;

            this.Create(submition);

            string[] testCases = problem.Tests.Select(t => t.TestParameters).ToArray();

            SubmitionModel model = this.codeTestingService.TestCode(source, laungage, testCases);

            //TODO Finish :)
        }
    }
}
