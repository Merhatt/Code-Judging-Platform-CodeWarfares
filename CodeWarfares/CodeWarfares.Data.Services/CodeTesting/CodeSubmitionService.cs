using CodeWarfares.Data.Models;
using CodeWarfares.Data.Models.Factories;
using CodeWarfares.Data.Services.Contracts.Account;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
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

        public CodeSubmitionService(ICodeTestingServices codeTestingService, IUserServices userService, ISubmitionFactory submitionFactory)
        {
            this.codeTestingService = codeTestingService;
            this.userService = userService;
            this.submitionFactory = submitionFactory;
        }

        public void SendSubmition(User user, Problem problem, string source)
        {
            Submition submition = this.submitionFactory.Create();
            submition.Code = source;
            submition.Author = user;
            submition.Problem = problem;
            submition.TestCounts = problem.TestsCount;

            this.userService.AddSubmitionToUser(user.Id, submition);
        }
    }
}
